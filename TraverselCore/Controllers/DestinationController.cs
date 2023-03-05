using BusiinessLayer.Abstract;
using EntityLayer.Concreate;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace TraverselCore.Controllers
{
	[AllowAnonymous]
	public class DestinationController : Controller
    {
        private readonly IService<Destination> _service;
        private readonly IService<Comment> service1;
        private readonly UserManager<AppUser> _userManager;
        public DestinationController(IService<Destination> service, IService<Comment> service1, UserManager<AppUser> userManager)
        {
            this._service = service;
            this.service1 = service1;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            var model =await _service.GetAllAsync();
           
            return View(model);
        }
        [HttpGet]
        public async Task<IActionResult> Details(Guid id)
        {
           
                ViewBag.x = id;
                ViewBag.DestinationId = id;
            if (User.Identity.IsAuthenticated)
            {
                var model1 = await _userManager.FindByNameAsync(User.Identity.Name);

                ViewBag.userName = model1.Name;
                ViewBag.v = model1.Id.ToString();

            }
            
                
                
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
