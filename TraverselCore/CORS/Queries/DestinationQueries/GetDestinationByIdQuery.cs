namespace TraverselCore.CORS.Queries.DestinationQueries
{
    public class GetDestinationByIdQuery
    {
        public GetDestinationByIdQuery(Guid id)
        {
            this.Id = id;
        }

        public Guid Id { get; set; }
    }
}
