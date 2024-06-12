using Kota2001Web.Data.Entities;
using Kota2001Web.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Kota2001Web.Controllers
{
    public class UserController : Controller
    {
        private readonly SignInManager<User> signInManager;
        private readonly UserManager<User> userManager;

        public UserController(
            SignInManager<User> signInManager,
            UserManager<User> userManager
            )
        {
            this.signInManager = signInManager;
            this.userManager = userManager;
        }
        [HttpGet]
        public IActionResult Register()
        {
            var model = new RegisterFormModel();
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegisterFormModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var newUser = new User()
            {
                Email = model.Email,
                FirstName = model.FirstName,
                LastName = model.LastName,
                PhoneNumber = model.PhoneNumber,
                UserName = model.Email
            };
          var result = await userManager.CreateAsync(newUser, model.Password);
            if (result.Succeeded == false)
            {
                ModelState.AddModelError("Error", result.Errors.FirstOrDefault().Description);
                return View(model);
            }
            var user = await userManager.FindByEmailAsync(newUser.Email);
             await signInManager.SignInAsync(user, model.IsPersistent);

            return RedirectToAction(nameof(HomeController.Index), "Home");
        }
        [HttpGet]
        public IActionResult Login()
        {
            var model = new LoginFormModel();
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginFormModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var user = await userManager.FindByEmailAsync(model.Email);
            if (user == null)
            {
                ModelState.AddModelError("Error", "Входът е неуспешен");
                  return View(model);
            }
            var validPassword = await userManager.CheckPasswordAsync(user, model.Password);
            if (!validPassword)
            {
                ModelState.AddModelError("Error", "Входът е неуспешен");
                return View(model);
            }
            await signInManager.SignInAsync(user, model.IsPersistent);
            return RedirectToAction(nameof(HomeController.Index), "Home");

        }
    }
}
