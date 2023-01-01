using BusiinessLayer.Abstract;
using EntityLayer.Concreate;
using Microsoft.AspNetCore.Mvc;

namespace TraverselCore.Controllers
{
    public class DestinationController : Controller
    {
        private readonly IService<Destination> _service;

        public DestinationController(IService<Destination> service)
        {
            this._service = service;
        }

        public async Task<IActionResult> Index()
        {
            var model =await _service.GetAllAsync();
            return View(model);
        }
        [HttpGet]
        public IActionResult Details(int id)
        {
            return View();
        }
        [HttpPost]
        public IActionResult Details(Destination destination)
        {
            return View();
        }
    }
}
