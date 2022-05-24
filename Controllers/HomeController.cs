using Kimball.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Kimball.Controllers {
    public class HomeController :Controller {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger) {
            _logger=logger;
        }

        public IActionResult Index() {
            return RedirectToAction("Index", "Records");
        }

        public IActionResult Privacy() {
            return RedirectToAction("Index","Records");
        }

        [ResponseCache(Duration = 0,Location = ResponseCacheLocation.None,NoStore = true)]
        public IActionResult Error() {
            return View(new ErrorViewModel { RequestId=Activity.Current?.Id??HttpContext.TraceIdentifier });
        }
    }
}