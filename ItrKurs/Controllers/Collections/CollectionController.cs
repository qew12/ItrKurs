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



namespace ItrKurs.Controllers
{
    public class CollectionController : Controller
    {
        public static string[] _additionalFields;
        public ApplicationDbContext db;
        private IWebHostEnvironment hostingEnv;
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        public User _currentUser;

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

        public virtual async Task<IActionResult> Index()
        {
            //db.Collections.FindAsync()
            return View(await db.Collections.ToListAsync());
        }
        public virtual IActionResult CreateCollection()
        {
            return View();
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




    }
}
