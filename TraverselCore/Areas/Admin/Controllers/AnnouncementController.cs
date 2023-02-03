using AutoMapper;
using BusiinessLayer.Abstract;
using DtoLayer.DTOs.AnnouncementDTOs;
using EntityLayer.Concreate;
using Microsoft.AspNetCore.Mvc;

namespace TraverselCore.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AnnouncementController : Controller
    {
        private readonly IService<Announcement> _service;
        private readonly IMapper _mapper;

        public AnnouncementController(IService<Announcement> service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var model = _mapper.Map<List<AnnouncementListDTO>>(await _service.GetAllAsync());
            return View(model);
        }
        [HttpGet]
        public async Task<IActionResult> AddAnnouncement()
        {
            
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddAnnouncement(Announcement announcement)
        {
            await _service.AddAsync(announcement);
            await _service.SaveChangesAsync();

            return View();
        }
    }
}
