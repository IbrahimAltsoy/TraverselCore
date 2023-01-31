using BusiinessLayer.Abstract;
using BusiinessLayer.ValidationRules;
using DataAccessLayer;
//using DocumentFormat.OpenXml.Presentation;
using EntityLayer.Concreate;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using NToastNotify;
using static TraverselCore.ToastrMessage.ToastrMessage;

namespace TraverselCore.Areas.Admin.Controllers
{
    [Area("Admin")]
    
    public class GuideController : Controller
    {
        private readonly IService<Guide> _guideService;
        private readonly IToastNotification _toastNotification;

        public GuideController(IService<Guide> guideService, IToastNotification toastNotification)
        {
            _guideService = guideService;
            _toastNotification = toastNotification;
        }
       
        public async Task<IActionResult> Index()
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
                return Redirect("/Admin/Guide/Index/");
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
        
        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            var model =await _guideService.FindAsync(id);
            return View(model);
        }
        
        [HttpPost]
        public IActionResult Edit(Guide guide)
        {
           _guideService.Update(guide);
            _guideService.SaveChanges();
            _toastNotification.AddSuccessToastMessage(MessajeToastr.ToastrUpdateSuccesfull(guide.Name),
                                   new ToastrOptions
                                   {
                                       Title = "Başarılı!!!"
                                   });
            return Redirect("/Admin/Guide/Index/");
        }
           
      
        
        public async Task<IActionResult> ChangeToTrue(Guid id)
        {

            var model = await _guideService.GuidesstatuChangeToTrue(id);
            
            
            return Redirect("/Admin/Guide/Index/");
        }

       
        
        //public async Task<IActionResult> ChangeToFalse(Guid id)
        //{
        //    var model = await _guideService.GetByGuidAsync(id);
        //    model.Statu = false;
        //    _guideService.Update(model);
        //    await _guideService.SaveChangesAsync();
        //    return Redirect("/Admin/Guide/Index/");
        //}
        //[Route("ChangeGuideStatus/{id}")]
        //[HttpPost]
        //public async Task<IActionResult> ChangeGuideStatus(Guid id)
        //{
        //    Context c = new Context();
        //    var guide = await c.Guides.FindAsync(id);
        //    guide.Statu = guide.Statu ? false : true;

        //   await c.SaveChangesAsync();
        //    return RedirectToAction("Index", "Guide", new { area = "Admin" });
        //    //var model = await _guideService.GetByGuidAsync(id);
        //    //model.Statu = model.Statu==true ? false : true;           
        //    //await _guideService.SaveChangesAsync();           
        //    //await _guideService.SaveChangesAsync();
        //    //return Redirect("/Admin/Guide/Index/");
        //}


    }
}
