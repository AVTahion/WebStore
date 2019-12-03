using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebStore.Domain.Entities.Identity;
using WebStore.ViewModels.Identity;

namespace WebStore.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly ILogger<AccountController> _logger;

        public AccountController(UserManager<User> userManager, SignInManager<User> signInManager, ILogger<AccountController> logger)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
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

            _logger.LogInformation("регистрация нового пользователя {0}", Model.UserName);

            var register_result = await _userManager.CreateAsync(user, Model.Password);
            if (register_result.Succeeded)
            {
                await _userManager.AddToRoleAsync(user, Role.User);
                _logger.LogInformation("Пользователь {0} зарегистрирован", Model.UserName);
                await _signInManager.SignInAsync(user, false);
                _logger.LogInformation("Пользователь {0} вошел в систему", Model.UserName);
                return RedirectToAction("Index", "Home");
            }

            foreach (var error in register_result.Errors) ModelState.AddModelError("", error.Description);

            _logger.LogWarning("Ошибка при регистрации пользователя {0}:{1}", Model.UserName, string.Join(", ", register_result.Errors.Select(e => e.Description)));

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
                _logger.LogInformation("Пользователь {0} вошел в систему", Model.UserName);

                if (Url.IsLocalUrl(Model.ReturnUrl))
                    return Redirect(Model.ReturnUrl);
                return RedirectToAction("Index", "Home");
            }

            ModelState.AddModelError("", "Неверное имя пользователя, или пароль");

            _logger.LogWarning("Ошибка при входе пользователя {0}", Model.UserName);

            return View(Model);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Logout()
        {
            var user_name = User.Identity.Name;
            await _signInManager.SignOutAsync();
            _logger.LogInformation("Пользователь {0} вышел из системы", user_name);
            return RedirectToAction("Index", "Home");
        }

    }
}