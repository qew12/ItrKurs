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
        public BookController(ApplicationDbContext context, IHostingEnvironment env, UserManager<User> userManager, SignInManager<User> signInManager, IHttpContextAccessor httpContextAccessor) : base(context, env, userManager, signInManager, httpContextAccessor)
        {
        }
        public override IActionResult CreateCollection()
        {
            _additionalFields = new string[5] { "Date", "Genres", "Comment", "Author", "Pages"};
            ViewBag.strArray = _additionalFields;
            return View("~/Views/Collection/CreateBookCollection.cshtml");
        }

        public  IActionResult AddToCollection(byte bitMask)
        {
            ViewBag.bit = bitMask;       
            return View("~/Views/Collection/AddBookToCollection.cshtml");
        }

        public async Task<IActionResult> hui2()
        {
            _currentUser = await GetCurrentUser();
            var books = db.Books.Where(p => p.IdOwner == _currentUser.Id && p.Discriminator == "Book").ToList();
            if (books != null)
            {
                ViewBag.Books = books;
                return View("~/Views/Collection/hui.cshtml");

            }         
            return CreateCollection();
        }


        public async Task<IActionResult> hui()
        {
            _currentUser = await GetCurrentUser();
            var books = db.Books.Where(p => p.IdOwner == _currentUser.Id && p.Discriminator == "Book").ToList();
            if (books != null)
            {               
                ViewBag.Books = books;
                return AddToCollection(books[0].bitMask);
            }
            else return CreateCollection();
        }


        [HttpPost]
        public async Task<IActionResult> CreateCollection(Book book)
        {
            _currentUser = await GetCurrentUser();
            Book _book = book;
            _book.IdOwner = _currentUser.Id;
            //_currentUser.Collections.Add(_book);

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
