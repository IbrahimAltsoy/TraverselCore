using BusiinessLayer.Abstract;
using EntityLayer.Concreate;
using Microsoft.AspNetCore.Mvc;

namespace TraverselCore.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ContactUsController : Controller
    {
        private readonly IContactUsService _contactUsService;

        public ContactUsController(IContactUsService contactUsService)
        {
            _contactUsService = contactUsService;
        }

        //[Guid("52D18FD7-772A-48D1-968F-DD4D794D710E")]
        public async Task<IActionResult> Index()
        {
            var modul = await _contactUsService.GetByMessageIsDeletedFalse();
            int y = 5;
            return View(modul);
        }
        public async Task<IActionResult> ChangeToIsDeleted(Guid id)
        {

            var model = await _contactUsService.ChangesMessageStatuWithContactUs(id);


            return Redirect("/Admin/ContactUs/Index/");
        }
    }
}
