using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using System.Diagnostics;

using user_management.Models;

namespace user_management.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string username, string password)
        {
            // ���� ������ �������� ������� ������ ������������
            // ��������, ����� ������������ ASP.NET Core Identity ��� ��������������

            // ������ ������� �������� ��� ����� ������������
            if (username == "admin" && password == "admin")
            {
                // �������� ��������������
                return RedirectToAction("HelloPage");
            }

            // ��������� ��������������
            return RedirectToAction("Index");
        }

        [Authorize]
        public IActionResult HelloPage()
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
