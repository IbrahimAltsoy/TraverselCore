using BusiinessLayer.Abstract;
using EntityLayer.Concreate;
using Microsoft.AspNetCore.Mvc;
using NToastNotify;
using static TraverselCore.ToastrMessage.ToastrMessage;

namespace TraverselCore.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class DestinationController : Controller
    {
        private readonly IService<Destination> _service1;
        private readonly IToastNotification toastNotification;       

        public DestinationController(IService<Destination> service1, IToastNotification toastNotification)
        {
            _service1 = service1;
            this.toastNotification = toastNotification;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
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
            toastNotification.AddSuccessToastMessage(MessajeToastr.ToastrAddSuccesfull(destination.City),
                                   new ToastrOptions
                                   {
                                       Title = "Başarılı!!!"
                                   });
            return Redirect("/Admin/Destination/Index/");
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
            toastNotification.AddSuccessToastMessage(MessajeToastr.ToastrUpdateSuccesfull(destination.City),
                                   new ToastrOptions
                                   {
                                       Title = "Başarılı!!!"
                                   });

            return Redirect("/Admin/Destination/Index/");
        }
        
        [HttpGet]
        public IActionResult DeleteDestination(Guid id,Destination destination)
        {
            toastNotification.AddSuccessToastMessage(MessajeToastr.ToastrDeleteSuccessful(destination.City),
                                   new ToastrOptions
                                   {
                                       Title = "Başarılı!!!"
                                   });
            _service1.Delete(destination);
            _service1.SaveChanges();
            
            return Redirect("/Admin/Destination/Index/");
        }

    }
}
