using BusiinessLayer.Abstract;
using EntityLayer.Concreate;
using Microsoft.AspNetCore.Mvc;

namespace TraverselCore.Controllers
{
    public class CommentController : Controller
    {
        private readonly IService<Destination> _service1;
        private readonly IService<Comment> _service2;

        public CommentController(IService<Destination> service1, IService<Comment> service2)
        {
            _service1 = service1;
            _service2 = service2;

        }
        [HttpGet]
        public PartialViewResult AddComment()
        {
            return PartialView();
        }
        [HttpPost]
        public async Task<IActionResult> AddComment(Comment comment)
        {
            comment.DateTime = Convert.ToDateTime(DateTime.Now);
            comment.Id = Guid.NewGuid();
            //comment.DestinationId = Guid.Parse("463edb75-7b0e-4770-891c-6a3f3fb847d7");
            comment.Status = true;
            //comment.User = user;
            //comment.Content = content;, string user, string content



            await _service2.AddAsync(comment);
            await _service2.SaveChangesAsync();
            return RedirectToAction("Index", "Destination");
        }
    }
}
