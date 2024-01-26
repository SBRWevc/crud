using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

using System.Diagnostics;
using user_management.Models;

namespace user_management.Controllers
{
    public class AccountController : Controller
    {
        private readonly ILogger<AccountController> _logger;
        private readonly SignInManager<UserViewModel> _signInManager;
        private readonly UserManager<UserViewModel> _userManager;

        public AccountController(ILogger<AccountController> logger, 
            SignInManager<UserViewModel> signInManager, UserManager<UserViewModel> userManager)
        {
            _logger = logger;
            _signInManager = signInManager;
            _userManager = userManager;
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SignIn(string username, string password)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByNameAsync(username);
                if (user != null)
                {
                    var result = await _signInManager.PasswordSignInAsync(user, password, false, lockoutOnFailure: false);

                    if (result.Succeeded)
                    {
                        _logger.LogInformation("User logged in.");
                        return View("Login"); // Замените "Index" и "Home" на ваши значения
                    }
                }

                ModelState.AddModelError(string.Empty, "Invalid login attempt");
            }

            return View("Login");
        }

        [HttpPost]
        public async Task<IActionResult> LogOut()
        {
            await _signInManager.SignOutAsync();

            // Опционально: Вы можете также выйти из всех внешних систем аутентификации (например, Google, Facebook)
            await HttpContext.SignOutAsync(IdentityConstants.ExternalScheme);

            _logger.LogInformation("User logged out.");

            return RedirectToAction("Login"); // Замените "Index" и "Home" на ваши значения
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
