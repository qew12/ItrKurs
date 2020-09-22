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
    public class AnimeController : CollectionController
    {
        [Obsolete]
        public AnimeController(ApplicationDbContext context, IHostingEnvironment env, UserManager<User> userManager, SignInManager<User> signInManager, IHttpContextAccessor httpContextAccessor) : base(context, env, userManager, signInManager, httpContextAccessor)
        {
        }
        public override IActionResult CreateCollection()
        {
            _additionalFields = new string[6] { "Date", "Genres", "Studio", "Author", "Episodes", "Image" };
            ViewBag.strArray = _additionalFields;
            return View("~/Views/Collection/CreateAnimeCollection.cshtml");
        }

        public IActionResult AddToCollection(byte bitMask)
        {
            ViewBag.bit = bitMask;
            return View("~/Views/Collection/AddAnimeToCollection.cshtml");
        }

        public async Task<IActionResult> hui2()
        {
            _currentUser = await GetCurrentUser();
            var animes = db.Books.Where(p => p.UserId == _currentUser.Id && p.Discriminator == "Anime").ToList();
            if (animes != null)
            {
                ViewBag.Animes = animes;
                return View("~/Views/Collection/hui.cshtml");

            }
            return CreateCollection();
        }


        public async Task<IActionResult> Create()
        {
            _currentUser = await GetCurrentUser();
            var animes = db.Animes.Where(p => p.UserId == _currentUser.Id && p.Discriminator == "Anime").ToList();
            if (animes != null && animes.Count > 0)
            {
                ViewBag.Animes = animes;
                return AddToCollection(animes[0].bitMask);
            }
            else return CreateCollection();
        }


        [HttpPost]
        public async Task<IActionResult> CreateCollection(Anime anime)
        {
            _currentUser = await GetCurrentUser();
            _currentUser.Collections.Add(anime);
            db.Animes.Add(anime);
            await db.SaveChangesAsync();
            return RedirectToAction("Index", "Collection");
        }
    }
}
