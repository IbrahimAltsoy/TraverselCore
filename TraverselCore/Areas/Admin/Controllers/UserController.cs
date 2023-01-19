using BusiinessLayer.Abstract;
using EntityLayer.Concreate;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NToastNotify;

namespace TraverselCore.Areas.Admin.Controllers
{
    [Area(nameof(Admin))]
    public class UserController : Controller
    {
        private readonly IService<AppUser> _service1;
        private readonly IToastNotification toastNotification;
        private readonly IService<Reservation> _reservationService;
        private readonly UserManager<AppUser> _userManager;
        public UserController(IService<AppUser> service1, IToastNotification toastNotification, IService<Reservation> reservationService, UserManager<AppUser> userManager)
        {
            _service1 = service1;
            this.toastNotification = toastNotification;
            _reservationService = reservationService;
            _userManager = userManager;
        }
        public IActionResult Index()
        {
            var model= _service1.GetAll();
            return View(model);
        }
        public IActionResult DeleteUser(Guid id)
        {
            var model = _service1.Find(id);
            _service1.Delete(model);
            _service1.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public IActionResult EditUser(Guid id)
        {
            var model = _service1.Find(id);
            return View(model);
        }
        [HttpPost]
        public IActionResult EditUser(AppUser appUser) 
        {
            _service1.Update(appUser);
            _service1.SaveChanges();

            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> ReservationUserAsync(Guid id)
        {
           // var model =await _userManager.FindByNameAsync(User.Identity.Name);
            var modelList = _reservationService.GetListWithReservationByapproved(id);
            
            return View(modelList);
        }
    }
}
