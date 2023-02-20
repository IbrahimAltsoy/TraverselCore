using DataAccessLayer;
using Microsoft.EntityFrameworkCore;
using TraverselCore.CORS.Queries.DestinationQueries;
using TraverselCore.CORS.Results.DestinationResults;

namespace TraverselCore.CORS.Handlers.DestinationHandlers
{
    public class GetAllDestinationQueryHandler
    {
        private readonly Context _context;

        public GetAllDestinationQueryHandler(Context context)
        {
            this._context = context;
        }
        public List<GetAllDestinationQueryResult> GetHandlers()
        {
            var modul = _context.Destinations.Select(x => new GetAllDestinationQueryResult
            {
                Id = x.Id,
                City = x.City,
                Capacity = x.Capacity,
                DayNight = x.DayNight,
                Price = x.Price

            }).AsNoTracking().ToList();
            return modul;
        }
        
       

    }
}
