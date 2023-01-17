using BusiinessLayer.Abstract;
using EntityLayer.Concreate;
using Microsoft.AspNetCore.Mvc;

namespace TraverselCore.Areas.Admin
{
    [Area("Admin")]
    public class DestinationController : Controller
    {
        private readonly IService<Destination> _service1;

        public DestinationController(IService<Destination> service1)
        {
            _service1 = service1;
        }
        [HttpGet]
        public async  Task<IActionResult> Index()
        {
            var model = await _service1.GetAllAsync();
            return View(model);
        }
        [HttpGet]
        public async Task<IActionResult> AddDestination()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddDestination(Destination destination)
        {
            destination.Statu = true;
            await _service1.AddAsync(destination);
            
            await _service1.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
        
        [HttpGet]
        public IActionResult UpdateDestination(Guid id)
        {
            var model = _service1.Find(id);
            return View(model);
        }
        [HttpPost]
        public IActionResult UpdateDestination(Destination destination)
        {
            _service1.Update(destination);
            _service1.SaveChanges();

            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public IActionResult DeleteDestination(Guid id)
        {
            var model =_service1.Find(id);
            _service1.Delete(model);
            _service1.SaveChanges();
            return View();
        }
        
    }
}
