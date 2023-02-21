namespace TraverselCore.CORS.Commands.DestinationCommands
{
    public class RemoveDestinationCommand
    {       
        public RemoveDestinationCommand(Guid id)
        {
            Id = id;
        }
        public Guid Id { get; set; }
    }
}
