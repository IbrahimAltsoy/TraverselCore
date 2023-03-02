using BusiinessLayer;
using TraverselCore.CORS.Queries.DestinationQueries;
using TraverselCore.CORS.Results.DestinationResults;

namespace TraverselCore.CORS.Handlers.DestinationHandlers
{
    public class GetDestinationByIdQueryHandler
    {
        private readonly Context _context;

        public GetDestinationByIdQueryHandler(Context context)
        {
            _context = context;
        }
        public GetDestinationByIdQueryResult GetByHandlers(GetDestinationByIdQuery p)
        {
            var model = _context.Destinations.Find(p.Id);
            return new GetDestinationByIdQueryResult
            {
                Id = model.Id,
                City = model.City,
                DayNight = model.DayNight,
                Price= model.Price,
            };
        }
    }
}
