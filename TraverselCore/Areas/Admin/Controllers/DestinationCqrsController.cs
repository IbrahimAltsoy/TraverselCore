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
        public readonly RemoveDestinationcommandHandler _removeDestinationCommand;
        public readonly UpdateDestinationCommandHandler _updateDestinationCommand;

        public DestinationCqrsController(GetAllDestinationQueryHandler getAllDestinationQueryHandler, GetDestinationByIdQueryHandler getDestinationByIdQueryHandler, CreateDestinationCommandHandler createDestinationCommand, RemoveDestinationcommandHandler removeDestinationCommand, UpdateDestinationCommandHandler updateDestinationCommand)
        {
            _getAllDestinationQueryHandler = getAllDestinationQueryHandler;
            _getDestinationByIdQueryHandler= getDestinationByIdQueryHandler;
            _createDestinationCommand = createDestinationCommand;
            _removeDestinationCommand = removeDestinationCommand;
            _updateDestinationCommand = updateDestinationCommand;
        }

        public IActionResult Index()
        {
            var modul = _getAllDestinationQueryHandler.GetHandlers();
           
            return View(modul);
        }
        [HttpGet]
        public IActionResult GetDestination(Guid id)
        {
            var model = _getDestinationByIdQueryHandler.GetByHandlers(new GetDestinationByIdQuery(id));
            return View(model);
        }
        [HttpPost]
        public IActionResult GetDestination(UpdateDestinationCommand command)
        {
            _updateDestinationCommand.Handle(command);
            return View();
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
       
        public IActionResult DeleteDestination(Guid id)
        {
            _removeDestinationCommand.Handle(new RemoveDestinationCommand(id));
            return RedirectToAction("Index");
        }
        
        
    }
}
