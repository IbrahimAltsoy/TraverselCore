using MediatR;
using TraverselCore.CORS.Results.GuideResult;

namespace TraverselCore.CORS.Queries.GuideQueries
{
    public class GetAllGuideQuery:IRequest<List<GetAllGuideQueryResult>>
    {

    }
}
