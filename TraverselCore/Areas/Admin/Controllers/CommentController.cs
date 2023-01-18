using BusiinessLayer.Abstract;
using BusiinessLayer.Contcreate;
using EntityLayer.Concreate;
using Microsoft.AspNetCore.Mvc;

namespace TraverselCore.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CommentController : Controller
    {
        private readonly ICommentService _commentService;
        private readonly IService<Comment> _service;

        public CommentController(ICommentService commentService, IService<Comment> service)
        {
            _commentService = commentService;
            _service = service;
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
            _service.Delete(model);
            _service.SaveChanges();
           
            return View();
            
        }
    }
}
