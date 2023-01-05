using Microsoft.AspNetCore.Mvc;

namespace TraverselCore.Areas.Member.Controllers
{
    public class MessajeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
