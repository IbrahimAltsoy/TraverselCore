using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TraverselCore.CORS.Commands.DestinationCommands;
using TraverselCore.CORS.Handlers.DestinationHandlers;
using TraverselCore.CORS.Queries.DestinationQueries;

namespace TraverselCore.Areas.Admin.Controllers
{
    [AllowAnonymous]
    [Area("Admin")]
    public class DestinationCqrsController : Controller
    {
        private readonly GetAllDestinationQueryHandler _getAllDestinationQueryHandler;
        private readonly GetDestinationByIdQueryHandler _getDestinationByIdQueryHandler;
        public readonly CreateDestinationCommandHandler _createDestinationCommand;

        public DestinationCqrsController(GetAllDestinationQueryHandler getAllDestinationQueryHandler, GetDestinationByIdQueryHandler getDestinationByIdQueryHandler, CreateDestinationCommandHandler createDestinationCommand)
        {
            _getAllDestinationQueryHandler = getAllDestinationQueryHandler;
            _getDestinationByIdQueryHandler= getDestinationByIdQueryHandler;
            _createDestinationCommand = createDestinationCommand;
        }

        public IActionResult Index()
        {
            var modul = _getAllDestinationQueryHandler.GetHandlers();
            int a = 2;
            return View(modul);
        }
        [HttpGet]
        public IActionResult GetDestinationById(Guid id)
        {
            var model = _getDestinationByIdQueryHandler.GetByHandlers(new GetDestinationByIdQuery(id));
            return View(model);
        }
        [HttpGet]
        public IActionResult AddDestination()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddDestination(CreateDestinationCommand command)
        {
            _createDestinationCommand.Handle(command);
            return RedirectToAction("Index");
        }
    }
}
