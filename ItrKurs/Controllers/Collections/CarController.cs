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
    public class CarController : CollectionController
    {

        public CarController(ApplicationDbContext context, IWebHostEnvironment env, UserManager<User> userManager, SignInManager<User> signInManager, IHttpContextAccessor httpContextAccessor) : base(context,env, userManager, signInManager, httpContextAccessor)
        {
        }
        public override IActionResult CreateCollection()
        {
            _additionalFields = new string[] { "Date", "Brand", "Country", "Engine", "Mileage", "Image", "Bool1", "Bool2", "Bool3", "Int1", "Int2", "Int3", "Longtext1", "Longtext2", "Longtext3" };
            ViewBag.strArray = _additionalFields;
            return View("~/Views/Collection/CreateCarCollection.cshtml");
        }

        public IActionResult AddToCollection(int bitMask)
        {
            ViewBag.bit = bitMask;
            return View("~/Views/Collection/AddCarToCollection.cshtml");
        }

        public async Task<IActionResult> Create()
        {
            _currentUser = await GetCurrentUser();
            var cars = db.Cars.Where(p => p.UserId == _currentUser.Id && p.Discriminator == "Car").ToList();
            if (cars != null && cars.Count > 0)
            {
                //ViewBag.Books = cars;
                return AddToCollection(cars[0].bitMask);
            }
            else return CreateCollection();
        }


        [HttpPost]
        public async Task<IActionResult> CreateCollection(Car car)
        {
            car.DateCreate = DateTimeOffset.Now;
            _currentUser = await GetCurrentUser();
            _currentUser.Collections.Add(car);
            db.Cars.Add(car);
            await db.SaveChangesAsync();
            return RedirectToAction("Index", "Collection");
        }



        public async Task<IActionResult> hui2()
        {
            _currentUser = await GetCurrentUser();
            var books = db.Books.Where(p => p.UserId == _currentUser.Id && p.Discriminator == "Car").ToList();
            if (books != null)
            {
                ViewBag.Books = books;
                return View("~/Views/Collection/hui.cshtml");

            }
            return CreateCollection();
        }

    }
}
