using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

using System.Diagnostics;
using user_management.Models;

namespace user_management.Controllers
{
    public class AdminController : Controller
    {
        private readonly ILogger<AccountController> _logger;
        private readonly UserManager<UserViewModel> _userManager;

        public AdminController(ILogger<AccountController> logger, UserManager<UserViewModel> userManager)
        {
            _logger = logger;
            _userManager = userManager;
        }

        public IActionResult List()
        {
            var users = _userManager.Users.ToList();
            return View(users);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
