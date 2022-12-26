using Microsoft.AspNetCore.Mvc;

namespace TraverselCore.Controllers
{
    public class DefaultController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
