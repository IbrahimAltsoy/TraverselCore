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
        public async Task<IActionResult> AddAnnouncement(AnnouncementAddDTO announcementAddDTO)
        {
            if (ModelState.IsValid)
            {
                var model = _service.AddAsync(new Announcement
                {
                    Content = announcementAddDTO.Content,
                    Title = announcementAddDTO.Title,
                    CreatedDate = Convert.ToDateTime(DateTime.Now.ToShortDateString())
                }) ;
                await _service.SaveChangesAsync();
                return RedirectToAction("/Admin/Announcement/Index/");
            }

            return View(announcementAddDTO);
        }
    
        public async Task<IActionResult> AnnouncementDelete(Guid id)
        {
            var model =await _service.FindAsync(id);
            _service.Delete(model);
            await _service.SaveChangesAsync();
            return RedirectToAction("/Admin/Comment/Index/");
        }
        [HttpGet]
        public async Task<IActionResult> AnnouncementUpdate(Guid id)
        {
            var model = _mapper.Map<AnnouncementUpdateDto>(await _service.FindAsync(id));
            int x = 5;
            return View(model);
        }
        [HttpPost]      
        public async Task<IActionResult> AnnouncementUpdate(AnnouncementUpdateDto updateDto)
        {
            if (ModelState.IsValid)
            {
                 _service.Update(new Announcement
                {
                     Id= updateDto.Id,
                    Content = updateDto.Content,
                    Title = updateDto.Title,
                    CreatedDate = Convert.ToDateTime(DateTime.Now.ToShortDateString())
                    
                });
                await _service.SaveChangesAsync();
            }
            return RedirectToAction("/Admin/Comment/Index/");
        }
    }
}
