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

namespace ItrKurs.Controllers.Collections
{
    public class AnimeController : CollectionController
    {

        public AnimeController(ApplicationDbContext context) : base(context)
    {
    }
        public override IActionResult CreateCollection()
        {
            return View("~/Views/Collection/CreateAnimeCollection.cshtml");
        }
        [HttpPost]
        public async Task<IActionResult> CreateCollection(Anime anime)
        {
            db.Animes.Add(anime);
            await db.SaveChangesAsync();
            return RedirectToAction("Index", "Collection");
        }
    }
}
