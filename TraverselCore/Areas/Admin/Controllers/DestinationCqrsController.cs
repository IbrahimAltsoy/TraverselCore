using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
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

        public DestinationCqrsController(GetAllDestinationQueryHandler getAllDestinationQueryHandler, GetDestinationByIdQueryHandler getDestinationByIdQueryHandler)
        {
            _getAllDestinationQueryHandler = getAllDestinationQueryHandler;
            _getDestinationByIdQueryHandler= getDestinationByIdQueryHandler;
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
    }
}
