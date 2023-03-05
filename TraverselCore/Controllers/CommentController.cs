using BusiinessLayer.Abstract;
using EntityLayer.Concreate;
using Microsoft.AspNetCore.Identity;
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
        public async Task<PartialViewResult> AddComment()
        {                     
            return PartialView();
        }
        [HttpPost]
        public async Task<IActionResult> AddComment(Comment comment)
        {
            //User.Identity.IsAuthenticated
              comment.DateTime = Convert.ToDateTime(DateTime.Now);
                comment.Id = Guid.NewGuid();               
                comment.Status = true;             
                await _service2.AddAsync(comment);
                await _service2.SaveChangesAsync();
                int a = 5;
                return RedirectToAction("Index", "Destination");
            
            
        }
    }
}
