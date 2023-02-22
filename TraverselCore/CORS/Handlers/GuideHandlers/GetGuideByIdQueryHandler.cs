using MediatR;
using TraverselCore.CORS.Queries.GuideQueries;
using TraverselCore.CORS.Results.GuideResult;
using DataAccessLayer;
using Microsoft.AspNetCore.Http.HttpResults;

namespace TraverselCore.CORS.Handlers.GuideHandlers
{
    public class GetGuideByIDQueryHandler : IRequestHandler<GetGuideByIdQuery, GetGuideByIdQueryResult>
    {
        private readonly Context _context;

        public GetGuideByIDQueryHandler(Context context)
        {
            _context = context;
        }

        public async Task<GetGuideByIdQueryResult> Handle(GetGuideByIdQuery request, CancellationToken cancellationToken)
        {
            var modul = await _context.Guides.FindAsync(request.Id);
            return new GetGuideByIdQueryResult
            {
                Id = modul.Id,
                Name = modul.Name,
                Description = modul.Description
            };

        }
    }
}
