using BusiinessLayer.Abstract;
using EntityLayer.Concreate;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace TraverselCore.Areas.Member.Controllers
{
    [Area(nameof(Member))]
    public class ReservationController : Controller
    {
        private readonly IService<Destination> _destinationService;
        private readonly IService<Reservation> _reservationService;
       
        public ReservationController(IService<Destination> destinationService, IService<Reservation> serviceReservation)
        {
            this._destinationService = destinationService;
            this._reservationService = serviceReservation;
        }

        public IActionResult MyCurrentReservation()
        {
            return View();
        }
        public IActionResult MyOldReservation()
        {
            return View();
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
            reservation.Status = "Onay Bekliyor";
            _reservationService.AddAsync(reservation);
            _reservationService.SaveChanges();
            return RedirectToAction("MyCurrentReservation");
        }


    }
}
