﻿using BusiinessLayer.Abstract;
using EntityLayer.Concreate;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace TraverselCore.Areas.Member.Controllers
{
    [Area(nameof(Member))]
    public class ReservationController : Controller
    {
        private readonly IService<Destination> _destinationService;
        private readonly IService<Reservation> _reservationService;
        private readonly UserManager<AppUser> _userManager;
        public ReservationController(IService<Destination> destinationService, IService<Reservation> serviceReservation, UserManager<AppUser> userManager)
        {
            this._destinationService = destinationService;
            this._reservationService = serviceReservation;
            this._userManager = userManager;
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
            var model = await _userManager.FindByNameAsync(User.Identity.Name);
            var modelList= _reservationService.GetAll(r=>r.AppUserId==model.Id);
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
            reservation.Status = "Onay Bekliyor";
            _reservationService.AddAsync(reservation);
            _reservationService.SaveChanges();
            return RedirectToAction("MyCurrentReservation");
        }


    }
}
