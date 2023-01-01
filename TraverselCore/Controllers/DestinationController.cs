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
        public async Task<IActionResult> Details(Guid id)
        {
            var model = await _service.FindAsync(id);
                       
            return View(model);
        }
        [HttpPost]
        public IActionResult Details(Destination destination)
        {

            return View();
        }
    }
}
