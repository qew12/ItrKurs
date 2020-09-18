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

namespace ItrKurs.Controllers
{
    public class CollectionController : Controller
    {
        public static string[] _additionalFields;
        public ApplicationDbContext db;
        private IHostingEnvironment hostingEnv;
        public CollectionController(ApplicationDbContext context, IHostingEnvironment env)
        {
            this.hostingEnv = env;
            db = context;
        }

        [HttpPost]
        public IActionResult UploadFiles()
        {
            long size = 0;
            var files = Request.Form.Files;
            string name="";
            foreach (var file in files)
            {
                string filename = hostingEnv.WebRootPath
        + $@"\uploadedfiles\{file.FileName}";
                name = filename;
                size += file.Length;
                using (FileStream fs =
        System.IO.File.Create(filename))
                {
                    file.CopyTo(fs);
                    fs.Flush();
                }
            }
            string message = $"{files.Count} file(s) {name} bytes uploaded successfully!";
            return Json(message);
        }

        public virtual async Task<IActionResult> Index()
        {
            return View(await db.Collections.ToListAsync());
        }
        public virtual IActionResult CreateCollection()
        {
            return View();
        }
       /* [HttpPost]
        public virtual async Task<IActionResult> CreateCollection(Collection collection)
        {
            db.Collections.Add(collection);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }*/


       


    }
}
