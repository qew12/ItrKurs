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

namespace ItrKurs.Controllers
{
    public class CollectionController : Controller
    {
        public static string[] _additionalFields;
        public ApplicationDbContext db;
        public bool[] _addFieldsBool = new bool[5] { false, false, false, false, false };
        public int[] ids;
        public CollectionController(ApplicationDbContext context)
        {
            //_addFields = new bool[5] { false, false, false, false, false };
            ids = new int[5] { 1, 2, 3, 4, 5 };
            db = context;
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
