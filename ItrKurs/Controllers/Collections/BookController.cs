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

namespace ItrKurs.Controllers.Collections
{
    public class BookController : CollectionController
    {
        public BookController (ApplicationDbContext context ,IHostingEnvironment env) : base(context, env)
        {
        }
        public override IActionResult CreateCollection()
        {
            _additionalFields = new string[5] { "Date", "Genres", "Comment", "Author", "Pages"};
            ViewBag.strArray = _additionalFields;
            return View("~/Views/Collection/CreateBookCollection.cshtml");
        }

        [HttpPost]
        public async Task<IActionResult> CreateCollection(Book book)
        {
            Book _book = book;
            db.Books.Add(_book);
            await db.SaveChangesAsync();
            return RedirectToAction("Index", "Collection");
        }

        public IActionResult Refresh(string[] id)
        {
            try
            {
                
                return new JsonResult(1);
            }
            catch
            {
                return new JsonResult(0);
            }
            
               
        }

    }
}
