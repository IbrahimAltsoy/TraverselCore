using BusiinessLayer.Abstract;
using BusiinessLayer.Contcreate;
using EntityLayer.Concreate;
using Microsoft.AspNetCore.Mvc;
using NToastNotify;
using static TraverselCore.ToastrMessage.ToastrMessage;

namespace TraverselCore.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CommentController : Controller
    {
        private readonly ICommentService _commentService;
        private readonly IService<Comment> _service;
        private readonly IToastNotification toastNotification;

        public CommentController(ICommentService commentService, IService<Comment> service, IToastNotification toastNotification)
        {
            _commentService = commentService;
            _service = service;
            this.toastNotification = toastNotification;
        }

        public async Task<IActionResult> Index()
        {
            var model = await _commentService.GetAllCommentWithDestinationAsync();
            return View(model);
        }
        [HttpGet]
        public IActionResult DeleteComment(Guid id)
        {
            var model = _service.Find(id);
            toastNotification.AddSuccessToastMessage(MessajeToastr.ToastrDeleteSuccessful("İçerik"),
                      new ToastrOptions
                      {
                          Title = "Başarılı!!!"
                      });
            _service.Delete(model);
            _service.SaveChanges();
           

            return RedirectToAction("/Admin/Comment/Index/");

        }
    }
}
