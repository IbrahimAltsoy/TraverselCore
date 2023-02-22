using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TraverselCore.CORS.Commands.GuideCommands;
using TraverselCore.CORS.Queries.GuideQueries;

namespace TraverselCore.Areas.Admin.Controllers
{
    [Area("Admin")]
    [AllowAnonymous]
    public class GuideMediarTController : Controller
    {
        private readonly IMediator _mediator;

        public GuideMediarTController(IMediator mediator)
        {
            this._mediator = mediator;
        }

        public async Task<IActionResult> Index()
        {
            var modul = await _mediator.Send(new GetAllGuideQuery());
            return View(modul);
        }
        [HttpGet]
        public async Task<IActionResult> GetGuides(Guid id)
        {
            var values = await _mediator.Send(new GetGuideByIdQuery(id));            
            return View(values);
        }
        [HttpGet]
        public IActionResult AddGuide()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddGuide(CreateGuideCommand command)
        {
            await _mediator.Send(command);
            return RedirectToAction("Index");
        }

    }
    
}
