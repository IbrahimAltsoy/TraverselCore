using MediatR;
using TraverselCore.CORS.Queries.GuideQueries;
using TraverselCore.CORS.Results.GuideResult;

namespace TraverselCore.CORS.Queries.GuideQueries
{
    public class GetGuideByIdQuery:IRequest<GetGuideByIdQueryResult>
    {
               
        public GetGuideByIdQuery(Guid id)
        {
            Id = id;
        }
        public Guid Id { get; set; }
    }
}
