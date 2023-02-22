using DataAccessLayer;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TraverselCore.CORS.Queries.GuideQueries;
using TraverselCore.CORS.Results.GuideResult;

namespace TraverselCore.CORS.Handlers.GuideHandlers
{
    public class GetAllGuideQueryHandler : IRequestHandler<GetAllGuideQuery, List<GetAllGuideQueryResult>>
    {
        private readonly Context _context;

        public GetAllGuideQueryHandler(Context context)
        {
            _context = context;
        }

        public async Task<List<GetAllGuideQueryResult>> Handle(GetAllGuideQuery request, CancellationToken cancellationToken)
        {
            return await _context.Guides.Select(x => new GetAllGuideQueryResult
            {
                Id= x.Id,
                Name= x.Name,
                Description= x.Description,
                Image = x.Image

            }).AsNoTracking().ToListAsync();
        }
    }
}
