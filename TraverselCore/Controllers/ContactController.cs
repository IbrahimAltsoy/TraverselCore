using AutoMapper;
using BusiinessLayer.Abstract;
using DocumentFormat.OpenXml.Wordprocessing;
using DtoLayer.DTOs.ContactDTOs;
using EntityLayer.Concreate;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NToastNotify;
using static TraverselCore.ToastrMessage.ToastrMessage;

namespace TraverselCore.Controllers
{
    [AllowAnonymous]
    public class ContactController : Controller
    {
        private readonly IService<ContactUs> _service;
        private readonly IMapper _mapper;
        private readonly IToastNotification _toastNotification;
        private readonly IValidator<SendMessageDto> _validator;


        public ContactController(IService<ContactUs> service, IMapper mapper, IToastNotification toastNotification, IValidator<SendMessageDto> validator)
        {
            _service = service;
            _mapper = mapper;
            _toastNotification = toastNotification;
            _validator = validator;
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(SendMessageDto send)
        {
            var result = _validator.Validate(send);
            if (result.IsValid)
            {
               _service.Add(new ContactUs()
                {
                    Name= send.Name,
                    Mail = send.Mail,
                    Subject= send.Subject,
                    MessageBody= send.MessageBody,
                    MessageDate = Convert.ToDateTime(DateTime.Now.ToShortDateString()),
                    IsDeleted= true
                }                
                );
                _toastNotification.AddSuccessToastMessage(MessajeToastr.ToastrAddSuccesfull(send.Subject),
                                   new ToastrOptions
                                   {
                                       Title = "Başarılı!!!"
                                   });
                return RedirectToAction(nameof(Index));

            }

            return View(send);
        }
    }
}
