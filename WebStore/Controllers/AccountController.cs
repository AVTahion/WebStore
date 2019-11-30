using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebStore.Domain.Entities.Identity;
using WebStore.ViewModels.Identity;

namespace WebStore.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;

        public AccountController(UserManager<User> userManager, SignInManager<User> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public IActionResult Register() => View(new RegisterUserViewModel());

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterUserViewModel Model)
        {
            if (!ModelState.IsValid)
                return View(Model);

            var user = new User()
            {
                UserName = Model.UserName
            };

            var register_result = await _userManager.CreateAsync(user, Model.Password);
            if (register_result.Succeeded)
            {
                await _signInManager.SignInAsync(user, false);
                return RedirectToAction("Index", "Home");
            }

            foreach (var error in register_result.Errors)
            {
                ModelState.AddModelError("", error.Description);
            }

            return View(Model);
        }

        public IActionResult Login(string returnUrl) => View(new LoginViewModel { ReturnUrl = returnUrl});

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel Model)
        {
            if (!ModelState.IsValid)
                return View(Model);

            var login_result = await _signInManager.PasswordSignInAsync(
                Model.UserName,
                Model.Password,
                Model.RememberMe,
                true);

            if (login_result.Succeeded)
            {
                if (Url.IsLocalUrl(Model.ReturnUrl))
                    return Redirect(Model.ReturnUrl);
                return RedirectToAction("Index", "Home");
            }

            ModelState.AddModelError("", "Неверное имя пользователя, или пароль");
            return View(Model);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

    }
}