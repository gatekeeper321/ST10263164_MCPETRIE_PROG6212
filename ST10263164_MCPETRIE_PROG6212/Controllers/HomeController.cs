using Microsoft.AspNetCore.Mvc;
using ST10263164_MCPETRIE_PROG6212.Models;
using System.Diagnostics;

namespace ST10263164_MCPETRIE_PROG6212.Controllers
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
        public IActionResult PendingClaims()
        {
            return View();
        }
        public IActionResult CreateClaim()
        {
            return View();
        }
        public IActionResult MyClaims()
        {
            return View();
        }
        public IActionResult SelectLogin()
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
