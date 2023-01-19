using Microsoft.AspNetCore.Mvc;

namespace TraverselCore.Controllers
{
    public class ErrorPageController : Controller
    {
        public IActionResult ErrorNumber(int errorNumber)
        {

            return View();
        }
    }
}
