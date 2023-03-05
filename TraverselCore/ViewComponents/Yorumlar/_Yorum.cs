using BusiinessLayer;
using BusiinessLayer.Abstract;
using EntityLayer.Concreate;
using Microsoft.AspNetCore.Mvc;
namespace TraverselCore.ViewComponents.Yorumlar
{
    public class _Yorum :ViewComponent
    {
        private readonly IService<EntityLayer.Concreate.Destination> _service;
        private readonly IService<Comment> _service1;
        private readonly ICommentService _service2;
        private readonly Context _context;
        public _Yorum(IService<EntityLayer.Concreate.Destination> service, IService<Comment> service1, ICommentService service2, Context context)
        {
            this._service = service;
            this._service1 = service1;
            this._service2 = service2;
            _context= context;
        }
        [HttpGet]
        public async Task<IViewComponentResult> InvokeAsync(Guid id)
        {
            //var model = await _service1.FindAsync(id);
            ViewBag.commentCount = _context.Comments.Where(x => x.DestinationId == id).Count();
            //var model1 = await _service1.GetAllAsync(x=>x.DestinationId==id);
            var model1 = await _service2.GetAllCommentWithDestinationAndUserAsync(id);
            return View(model1);

        }


    }
}
