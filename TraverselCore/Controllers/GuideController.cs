using BusiinessLayer.Abstract;
using EntityLayer.Concreate;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace TraverselCore.Controllers
{
    [AllowAnonymous]
    public class GuideController : Controller
    {
        private readonly IService<Guide> _service;

        public GuideController(IService<Guide> service)
        {
            _service = service;
        }

        public async Task<IActionResult> Index()
        {
            var model =await _service.GetAllAsync(x=>x.Statu==false);
            int a = 5;
            return View(model);
        }
    }
}
