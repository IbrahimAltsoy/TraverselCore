using BusiinessLayer.Abstract;
using EntityLayer.Concreate;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace TraverselCore.Controllers
{
	[AllowAnonymous]
	public class DestinationController : Controller
    {
        private readonly IService<Destination> _service;
        private readonly IService<Comment> service1;

        public DestinationController(IService<Destination> service, IService<Comment> service1)
        {
            this._service = service;
            this.service1 = service1;
        }

        public async Task<IActionResult> Index()
        {
            var model =await _service.GetAllAsync();
           
            return View(model);
        }
        [HttpGet]
        public async Task<IActionResult> Details(Guid id)
        {
            ViewBag.x= id;
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
