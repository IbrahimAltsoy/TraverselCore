using BusiinessLayer.Abstract;
using EntityLayer.Concreate;
using Microsoft.AspNetCore.Mvc;

namespace TraverselCore.Areas.Admin.Controllers
{
    [Area(nameof(Admin))]
    public class GuideController : Controller
    {
        private readonly IService<Guide> _guideService;

        public GuideController(IService<Guide> guideService)
        {
            _guideService = guideService;
        }

        public async Task<IActionResult> IndexAsync()
        {
            var model = await _guideService.GetAllAsync();
            return View(model);
        }
        [HttpGet]
        public async Task<IActionResult> AddGuide()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddGuide(Guide guide)
        {
            await _guideService.AddAsync(guide);
            await _guideService.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }


    }
}
