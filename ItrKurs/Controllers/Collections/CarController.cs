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

        public CarController(ApplicationDbContext context, IHostingEnvironment env, UserManager<User> userManager, SignInManager<User> signInManager, IHttpContextAccessor httpContextAccessor) : base(context,env, userManager, signInManager, httpContextAccessor)
        {
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
