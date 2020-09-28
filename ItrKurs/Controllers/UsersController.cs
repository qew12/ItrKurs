using System.Linq;
using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using ItrKurs.Models;
using ItrKurs.ViewModels;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace ItrKurs.Controllers
{
    public class UsersController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private User _currentUser;

        public UsersController(UserManager<User> userManager, SignInManager<User> signInManager, IHttpContextAccessor httpContextAccessor)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task<IActionResult> Index() 
        {
            _currentUser = await GetCurrentUser();

            User user = await _userManager.FindByIdAsync(_currentUser.Id);
            if(user.Role!="admin") return RedirectToAction("Index", "Collection");
            return View(_userManager.Users.ToList());
        }

        public IActionResult Create() => View();

        [HttpPost]

        private async Task<User> GetCurrentUser()
        {
            return await _userManager.GetUserAsync(HttpContext.User);
        }
        public async Task<JsonResult> Delete(string[] id)
        {
            try
            {
                _currentUser = await GetCurrentUser();
                bool needLogout = false;
                foreach (var idDelete in id)
                {
                    User user = await _userManager.FindByIdAsync(idDelete);
                    if (user != null)
                    {
                        if (idDelete == _currentUser.Id) needLogout = true;
                        await _userManager.DeleteAsync(user);
                    }
                }
                if (needLogout) await _signInManager.SignOutAsync();
                return new JsonResult(1);
            }
            catch
            {
                return new JsonResult(0);
            }
        }

        public async Task<JsonResult> EditStatus(string[] id, string block)
        {
            try
            {
                _currentUser = await GetCurrentUser();
                bool needLogout = false;
                foreach (var idDelete in id)
                {
                    User user = await _userManager.FindByIdAsync(idDelete);

                    if (user != null)
                    {
                        if (block.Equals("Unblock"))
                        {
                            user.LockoutEnabled = false;
                            user.IsSelected = false;
                            user.LockoutEnd = null;
                            await _userManager.UpdateAsync(user);
                        }
                        else
                        {

                            if (idDelete == _currentUser.Id) needLogout = true;
                            user.LockoutEnabled = true;
                            user.IsSelected = true;
                            user.LockoutEnd = DateTimeOffset.Now.AddMonths(5);
                            await _userManager.UpdateAsync(user);
                        }

                    }
                }
                if (needLogout) await _signInManager.SignOutAsync();
                return new JsonResult(1);
            }
            catch
            {
                return new JsonResult(0);
            }
        }





        public async Task<JsonResult> EditRole(string[] id, string role)
        {
            try
            {
                _currentUser = await GetCurrentUser();
                //bool needLogout = false;
                foreach (var idDelete in id)
                {
                    User user = await _userManager.FindByIdAsync(idDelete);

                    if (user != null)
                    {
                        if (role.Equals("admin"))
                        {
                            user.Role = "admin";
 
                            await _userManager.UpdateAsync(user);
                        }
                        else
                        {                           
                            user.Role = "";
                            await _userManager.UpdateAsync(user);
                        }

                    }
                }               
                return new JsonResult(1);
            }
            catch
            {
                return new JsonResult(0);
            }
        }

    }
}
