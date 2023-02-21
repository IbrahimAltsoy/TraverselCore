using DataAccessLayer;
using TraverselCore.CORS.Commands.DestinationCommands;

namespace TraverselCore.CORS.Handlers.DestinationHandlers
{
    public class RemoveDestinationcommandHandler
    {
        private readonly Context _context;

        public RemoveDestinationcommandHandler(Context context)
        {
            _context = context;
        }
        public void Handle(RemoveDestinationCommand command)
        {
            var modul = _context.Destinations.Find(command.Id);

            _context.Destinations.Remove(modul);
            _context.SaveChanges();

        }
    }
}
