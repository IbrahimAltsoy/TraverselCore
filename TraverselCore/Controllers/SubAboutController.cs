using BusiinessLayer.Abstract;
using EntityLayer.Concreate;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

namespace TraverselCore.Controllers
{
    public class SubAboutController : Controller
    {
        private readonly IService<SubAbout> _service;

        // veritabanı işlemleri için generic olarak tasarladığımız repository sınıfını kullanan service interface ini brand class ı için kullanılmak üzere tanımladık.

        public SubAboutController(IService<SubAbout> service)
        {
            this._service = service;
        }

        // GET: BrandsController
        public async Task<IActionResult> Index()
        {
            var model = await _service.GetAllAsync();


            return View(model);
        }
    }
}
//
//public class BrandsController : Controller
//{
//    private readonly IService<Brand> _service; // veritabanı işlemleri için generic olarak tasarladığımız repository sınıfını kullanan service interface ini brand class ı için kullanılmak üzere tanımladık.

//    public BrandsController(IService<Brand> service)
//    {
//        _service = service;
//    }

//    // GET: BrandsController
//    public async Task<IActionResult> Index()
//    {
//        var model = await _service.GetAllAsync();


//        return View(model);
//    }
//}