using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TraverselCore.Models;

namespace TraverselCore.Controllers
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
            _logger.LogInformation("Anasayfa çağrıldı");
            return View();
        }

        public IActionResult Privacy()
        {
            _logger.LogInformation($"{nameof(Privacy)} Çağrıldı");
            return View();
        }
        public IActionResult Deneme() 
        { 
            _logger.LogInformation("Deneme sayfası çağrıldı");
            return View();
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}