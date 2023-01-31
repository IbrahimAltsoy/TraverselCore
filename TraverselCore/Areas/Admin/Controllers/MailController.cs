using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using NToastNotify;
using TraverselCore.Models;
using static TraverselCore.ToastrMessage.ToastrMessage;

namespace TraverselCore.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class MailController : Controller
    {
        private readonly IToastNotification toastNotification;

        public MailController(IToastNotification toastNotification)
        {
            this.toastNotification = toastNotification;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(MailRequest mailRequest)
        {
            MimeMessage mimeMessage = new MimeMessage();
            MailboxAddress mailboxAddressFrom = new MailboxAddress("Admin", "altsoyibrahim01@gmail.com");
            mimeMessage.From.Add(mailboxAddressFrom);
            MailboxAddress mailboxAddressTo = new MailboxAddress("User", mailRequest.ReceiverMail);
            mimeMessage.To.Add(mailboxAddressTo);
            mimeMessage.Subject = mailRequest.Subject;
            //mimeMessage.Body = mailRequest.Body;
            // pwcqaccpivzbdabt 2 nin şifresi Şifre
            var bodyBuilder = new BodyBuilder();
            bodyBuilder.TextBody = mailRequest.Body;
            mimeMessage.Body = bodyBuilder.ToMessageBody();
            SmtpClient smtpClient = new SmtpClient();// bunu bu kütüphaneden ekledik. using MailKit.Net.Smtp;
            smtpClient.Connect("smtp.gmail.com", 587, false);
            smtpClient.Authenticate("altsoyibrahim01@gmail.com", "pwcqaccpivzbdabt");
            smtpClient.Send(mimeMessage);
            smtpClient.Disconnect(true);
            toastNotification.AddSuccessToastMessage(MessajeToastr.ToastrMailSuccessful(mimeMessage.Subject),
                      new ToastrOptions
                      {
                          Title = "Başarılı!!!"
                      });

            return View();
        }
    }
}
