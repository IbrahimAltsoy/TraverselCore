using BusiinessLayer.Abstract;
using DataAccessLayer;
using EntityLayer.Concreate;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace TraverselCore.Areas.Member.Controllers
{
    [Area(nameof(Member))]
    public class ReservationController : Controller
    {
        private readonly IService<Destination> _destinationService;
        private readonly IService<Reservation> _reservationService;
        private readonly UserManager<AppUser> _userManager;
        Context _context;
        public ReservationController(IService<Destination> destinationService, IService<Reservation> serviceReservation, UserManager<AppUser> userManager, Context context)
        {
            this._destinationService = destinationService;
            this._reservationService = serviceReservation;
            this._userManager = userManager;
            this._context = context;
        }

        public IActionResult MyCurrentReservation()
        {
            return View();
        }
        public IActionResult MyOldReservation()
        {
            return View();
        }
        public async Task<IActionResult> MyAprovalReservation()
        {
            //var model = _context.Reservations.Include(x => x.Destination).Where(x => x.Status == EnumStatu.StatuDurumu.Bekliyor && x.AppUserId == id).ToList();

            //return View(model);

            // (r => r.AppUserId == model.Id && r.Status == EnumStatu.StatuDurumu.Bekliyor); bunun yerine model.Id yazdık
            var model = await _userManager.FindByNameAsync(User.Identity.Name);
             var modelList = _reservationService.GetListWithReservationByWaitApproal(model.Id);

            return View(modelList);
        }
        [HttpGet]
        public IActionResult NewReservation()
        {
            List<SelectListItem> values = (from x in _destinationService.GetAll()
                                           select new SelectListItem
                                           {
                                               Text = x.City,
                                               Value = x.Id.ToString()
                                           
                                           }).ToList();
            ViewBag.v = values;
                
            return View();
        }
        [HttpPost]
        public IActionResult NewReservation(Reservation reservation)
        {
            reservation.AppUserId = Guid.Parse("585c6b1b-4d52-40f4-206f-08daee747b8c");
            reservation.Status = EnumStatu.StatuDurumu.Onaylanmış;
            _reservationService.AddAsync(reservation);
            _reservationService.SaveChanges();
            return RedirectToAction("MyCurrentReservation");
        }
        //[Guid("3C88C560-C485-4468-ABFE-E1BF129DB46C")]

    }
}
