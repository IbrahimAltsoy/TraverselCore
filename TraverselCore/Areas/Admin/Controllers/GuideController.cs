using BusiinessLayer.Abstract;
using BusiinessLayer.ValidationRules;
using EntityLayer.Concreate;
using FluentValidation;
using FluentValidation.Results;
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
            GuideValidator validationRules = new GuideValidator();
            ValidationResult result = validationRules.Validate(guide);
            if (result.IsValid)
            {
                await _guideService.AddAsync(guide);
                await _guideService.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            else
            {
                foreach(var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
                return View();
            }
            
           
        }


    }
}
