using Microsoft.AspNetCore.Mvc;

using System.Diagnostics;
using user_management.Models;

namespace user_management.Controllers
{
    public class AdminController(ILogger<AccountController> logger) : Controller
    {
        private readonly ILogger<AccountController> _logger = logger;

        public IActionResult List()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
