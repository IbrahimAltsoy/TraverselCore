using BusiinessLayer.Abstract;
using EntityLayer.Concreate;
using Microsoft.AspNetCore.Mvc;

namespace TraverselCore.Areas.Member.Controllers
{
    [Area("Member")]
    public class DestinationController : Controller
    {
        private readonly IService<Destination> _service1;
        private readonly IService<Comment> _service2;

        public DestinationController(IService<Destination> service1, IService<Comment> service2)
        {
            _service1 = service1;
            _service2 = service2;

        }
        public async Task<IActionResult> Index()
        {
            var model =await _service1.GetAllAsync();
            return View(model);
        }
    }
}
