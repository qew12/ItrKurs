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
using System.Reflection.Metadata.Ecma335;

namespace ItrKurs.Controllers
{
    public class CollectionController : Controller
    {
        public ApplicationDbContext db;
        private string _discriminator;
        private IWebHostEnvironment hostingEnv;
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        public User _currentUser;


        static readonly string[] collectionName = {"Book", "Car", "Anime"};
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
            await GetTop3();
            return View();
        }

        public async Task GetTop3()
        {
            var groups = from p in db.Collections
                         group p by new { p.UserId, p.Discriminator } into g
                         select new { Name = g.Key, Count = g.Count() };

            var collections = await groups.OrderByDescending(u => u.Count).Take(3).ToListAsync();
            
            List<Tuple<string, string, int>> tuple = new List<Tuple<string, string, int>>();
            foreach (var u in collections) 
            {
                User user = await db.Users.FirstOrDefaultAsync(x => x.Id == u.Name.UserId);
                tuple.Add(new Tuple<string, string, int>(user.Status, u.Name.Discriminator, u.Count));
            }
            var last3 = db.Collections.OrderByDescending(u => u.DateCreate).Take(3);
            ViewBag.top3 = tuple;
            ViewBag.last3 = last3;
            
        }
       
        public async Task<IActionResult> CollectionView(string userId)
        {
            IQueryable<Collection> collections;
            int bookLen = 0, carLen = 0, animeLen = 0;
            if (!String.IsNullOrEmpty(userId))
            {
                collections =  db.Collections.Where(p => p.UserId == userId);
            }
            else {
                _currentUser = await GetCurrentUser();
                userId = _currentUser.Id;
                collections = db.Collections.Where(p => p.UserId == userId);
            }
            
            if (collections != null && collections.Count() > 0)
            {
                var bookCollections = await collections.Where(p => p.Discriminator == "Book").ToListAsync();
                var carCollections = await collections.Where(p => p.Discriminator == "Car").ToListAsync();
                var animeCollections = await collections.Where(p => p.Discriminator == "Anime").ToListAsync();



                bookLen = (bookCollections != null ) ? bookCollections.Count : 0;
                carLen = (carCollections != null) ? carCollections.Count : 0;
                animeLen = (animeCollections != null) ? animeCollections.Count : 0;
          }
            ViewBag.userId = userId;
            ViewBag.bookLen = bookLen;
            ViewBag.carLen = carLen;
            ViewBag.animeLen = animeLen;
            return View();
        }





        public async Task<IActionResult> ItemView(string userId, string discriminator, string name, string description, SortState sortOrder = SortState.NameAsc)
        {
            if (String.IsNullOrEmpty(discriminator)) discriminator = "Book";
            _discriminator = discriminator;
            IQueryable<Collection> collections;

            if (!String.IsNullOrEmpty(userId))
            {
                collections = db.Collections.Where(p => p.UserId == userId && p.Discriminator == _discriminator);
            }
            else
            {
                _currentUser = await GetCurrentUser();
                userId = _currentUser.Id;
                collections = db.Collections.Where(p => p.UserId == userId && p.Discriminator == _discriminator);
            }
                  
            if (!String.IsNullOrEmpty(name))
            {
                collections = collections.Where(p => p.Name.Contains(name));
            }
            //ViewBag.userId = userId;
            //ViewBag.discriminator = _discriminator;

            switch (sortOrder)
            {
                case SortState.NameDesc:
                    collections = collections.OrderByDescending(s => s.Name);
                    break;
                case SortState.DescrAsc:
                    collections = collections.OrderBy(s => s.Discription);
                    break;
                case SortState.DescrDesc:
                    collections = collections.OrderByDescending(s => s.Discription);
                    break;
                case SortState.DateCreateAsc:
                    collections = collections.OrderBy(s => s.DateCreate);
                    break;
                case SortState.DateCreateDesc:
                    collections = collections.OrderByDescending(s => s.DateCreate);
                    break;
                default:
                    collections = collections.OrderBy(s => s.Name);
                    break;
            }
            
            PersonalCollectionViewModel viewModel = new PersonalCollectionViewModel
            {               
                SortViewModel = new SortViewModel(sortOrder),
                FilterViewModel = new FilterViewModel(db.Collections.ToList(), name, description,_discriminator,userId),
                Collections = await collections.AsNoTracking().ToListAsync()
            };
            return View(viewModel);
        }

        public async Task<User> GetCurrentUser()
        {
            return await _userManager.GetUserAsync(HttpContext.User);
        }

        public async Task<IActionResult> Create(string discriminator ,string userId)
        {
            List<Collection> collections;
            _discriminator = discriminator;
            if (!String.IsNullOrEmpty(userId))
            {
                collections = await db.Collections.Where(p => p.UserId == userId && p.Discriminator == _discriminator).ToListAsync();
            }
            else
            {
                _currentUser = await GetCurrentUser();
                userId = _currentUser.Id;
                collections = await db.Collections.Where(p => p.UserId == userId && p.Discriminator == _discriminator).ToListAsync();
            }
        
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
        public IActionResult AddToCollection(int bitMask)
        {
            PostData(bitMask);
            return View("~/Views/Collection/AddToCollection.cshtml");
        }

        [HttpPost]
        public async Task<IActionResult> CreateCollection(Collection collection)
        {
            collection.DateCreate = DateTimeOffset.Now;
            _currentUser = await GetCurrentUser();
            _currentUser.Collections.Add(collection);

            db.Collections.Add(collection);
            await db.SaveChangesAsync();
            return RedirectToAction("CollectionView", "Collection");
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
            if (s!=null&& s.Length>0)
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

        [HttpPost]
        public async Task<IActionResult> DeleteCollection(string userId, string discriminator)
        {
            List<Collection> collections;
            _discriminator = discriminator;
            if (!String.IsNullOrEmpty(userId))
            {
                collections = await db.Collections.Where(p => p.UserId == userId && p.Discriminator == _discriminator).ToListAsync();
            }
            else
            {
                _currentUser = await GetCurrentUser();
                userId = _currentUser.Id;
                collections = await db.Collections.Where(p => p.UserId == userId && p.Discriminator == _discriminator).ToListAsync();
            }
            if (collections != null)
            {
                foreach (Collection item in collections)
                {
                    db.Collections.Remove(item);
                    await db.SaveChangesAsync();                    
                }
                return RedirectToAction("CollectionView", "Collection");
            }
            return NotFound();
        }
    }
}
