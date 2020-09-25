using System.Linq;
using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using ItrKurs.Models;
using ItrKurs.ViewModels;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Hosting;
using System.IO;
using System.Collections.Generic;
using System.Text;

namespace ItrKurs.Controllers
{
    public class CollectionController : Controller
    {
        //public string[] _additionalFields;
        public ApplicationDbContext db;
        private string _discriminator;
        private IWebHostEnvironment hostingEnv;
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        public User _currentUser;

        static readonly Dictionary<string, string[]> _additionalFields = new Dictionary<string, string[]>
        {
            ["Book"] = new string[]{ "Date", "Pages", "Awards", "Size", "Readed", "Bool2", "Bool3", "Comment", "Genres", "Image" },
            ["Anime"] = new string[] { "Date", "Episodes", "Awards", "Rating", "Wached", "Bool2", "Bool3", "Comment", "Genres", "Image" },
            ["Car"] = new string[] { "Date", "Engine power", "Price", "Mileage", "Be used", "Bool2", "Bool3", "Comment", "Brend", "Image" }
        };

        public CollectionController(ApplicationDbContext context, IWebHostEnvironment env, UserManager<User> userManager, SignInManager<User> signInManager, IHttpContextAccessor httpContextAccessor)
        {
            this.hostingEnv = env ?? throw new ArgumentNullException(nameof(env));
            db = context;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [HttpPost]
        public IActionResult UploadFiles()
        {
            long size = 0;
            var files = Request.Form.Files;
            string name="";
            foreach (var file in files)
            {
                string filename = hostingEnv.WebRootPath+ "/uploadedfiles/" + file.FileName;
                name = file.FileName;
                size += file.Length;
                using (FileStream fs = System.IO.File.Create(filename))
                {
                    file.CopyTo(fs);
                    fs.Flush();
                }
            }
            
            string message = $"{name}  uploaded successfully!";
            name = $@"\uploadedfiles\{name}";
            return Json(name);
        }

        public void PostData(int? bitMask) {
            if(bitMask!=null)
            ViewBag.bit = bitMask;
            ViewBag.discriminator = _discriminator;
            ViewBag.m_additionalFields = _additionalFields[_discriminator];
        }
        public  async Task<IActionResult> Index()
        {
            return View(await db.Collections.ToListAsync());
        }
       

        public async Task<IActionResult> Main()
        {
            _currentUser = await GetCurrentUser();
            ViewBag.Collections = _currentUser.Collections;
            

            var collections = db.Collections.Where(p => p.UserId == _currentUser.Id).ToList();
            if (collections != null && collections.Count > 0)
            {
                ViewBag.Collections = collections;
                return View();
            }
            else return View(await db.Collections.ToListAsync());
        }


        public async Task<User> GetCurrentUser()
        {
            return await _userManager.GetUserAsync(HttpContext.User);
        }

        public IActionResult AddToCollection(int bitMask)
        {          
            PostData(bitMask);
            return View("~/Views/Collection/AddToCollection.cshtml");
        }

        public Task<IActionResult> CreateBook()
        {
            _discriminator = "Book";
            return Create();
        }
        public Task<IActionResult> CreateCar()
        {
            _discriminator = "Car";
            return Create();
        }
        public Task<IActionResult> CreateAnime()
        {
            _discriminator = "Anime";
            return Create();
        }


        public async Task<IActionResult> Create()
        {
            _currentUser = await GetCurrentUser();
            var collections = db.Collections.Where(p => p.UserId == _currentUser.Id && p.Discriminator == _discriminator).ToList();
            if (collections != null && collections.Count > 0)
            {
                return AddToCollection(collections[0].bitMask);
            }
            else return CreateCollection();
        }
        public IActionResult CreateCollection()
        {
            PostData(null);
            return View("~/Views/Collection/CreateCollection.cshtml");

        }

        [HttpPost]
        public async Task<IActionResult> CreateCollection(Collection collection)
        {
            collection.DateCreate = DateTimeOffset.Now;
            _currentUser = await GetCurrentUser();
            _currentUser.Collections.Add(collection);

            db.Collections.Add(collection);
            await db.SaveChangesAsync();
            return RedirectToAction("Index", "Collection");
        }

        public async Task<IActionResult> hui2(string Discriminator)
        {
            _currentUser = await GetCurrentUser();
            var collections = db.Collections.Where(p => p.UserId == _currentUser.Id && p.Discriminator == Discriminator).ToList();
            if (collections != null)
            {
                ViewBag.Books = collections;
                return View("~/Views/Collection/hui.cshtml");

            }
            return CreateCollection();
        }

        public Task<IActionResult> EditBook(int? id)
        {
            _discriminator = "Book";
            return Edit(id);
        }
        public Task<IActionResult> EditCar(int? id)
        {
            _discriminator = "Car";
            return Edit(id);
        }
        public Task<IActionResult> EditAnime(int? id)
        {
            _discriminator = "Anime";
            return Edit(id);
        }
        public async Task<IActionResult> Edit(int? id)
        {
            if (id != null)
            {
                Collection collection = await db.Collections.FirstOrDefaultAsync(p => p.Id == id);
                if (collection != null)
                {
                    PostData(null);
                    return View("~/Views/Collection/EditCollection.cshtml", collection);
                }
            }
            return NotFound();
        }
        [HttpPost]
        public async Task<IActionResult> EditCollection(Collection collection)
        {
            db.Collections.Update(collection);
            await db.SaveChangesAsync();
            return RedirectToAction("Main", "Collection");
        }



        public async Task<IActionResult> Details(int? id)
        {
            if (id != null)
            {
                Collection collection = await db.Collections.FirstOrDefaultAsync(p => p.Id == id);
                if (collection != null)
                {
                    _discriminator = collection.Discriminator;
                    PostData(null);

                    ViewBag.Comments = GetComments(collection.Comments);

                    return View("~/Views/Collection/Details.cshtml", collection);
                }
            }
            return NotFound();
        }



        [HttpGet]
        [ActionName("Delete")]
        public async Task<IActionResult> ConfirmDelete(int? id)
        {
            if (id != null)
            {
                Collection collection = await db.Collections.FirstOrDefaultAsync(p => p.Id == id);
                if (collection != null)
                    return View("~/Views/Collection/Delete.cshtml", collection);
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id != null)
            {
                Collection collection = await db.Collections.FirstOrDefaultAsync(p => p.Id == id);
                if (collection != null)
                {
                    db.Collections.Remove(collection);
                    await db.SaveChangesAsync();
                    return RedirectToAction("Index");
                }
            }
            return NotFound();
        }

        public List<(string, string)> GetComments(string s)
        {
            List<(string, string)> comments = new List<(string, string)>();
            if (s!=null)
            {
                
                string[] substr = s.Split(';');
                foreach (string item in substr)
                {
                    string[] tmp = item.Split('`');
                    comments.Add((tmp[0], tmp[1]));
                }                
            }
            return comments;
        }
        public async Task<JsonResult> Comment(int? id, string str)
        {
            if (id != null)
            {
                Collection collection = await db.Collections.FirstOrDefaultAsync(p => p.Id == id);
                if (collection != null)
                {
                    StringBuilder s = new StringBuilder();
                    _currentUser = await GetCurrentUser();
                    if (collection.Comments != null)
                    {
                        s.Append(collection.Comments);
                        s.Append($";{_currentUser.Status}`{str}");
                    }
                    else s.Append($"{_currentUser.Status}`{str}");

                    collection.Comments = s.ToString();

                    db.Collections.Update(collection);
                    await db.SaveChangesAsync();
                    return new JsonResult(1);
                }
            }
            return new JsonResult(0);
        }


    }
}
