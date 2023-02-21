using DataAccessLayer;
using TraverselCore.CORS.Commands.DestinationCommands;

namespace TraverselCore.CORS.Handlers.DestinationHandlers
{
    public class UpdateDestinationCommandHandler
    {
        private readonly Context _context;

        public UpdateDestinationCommandHandler(Context context)
        {
            _context = context;
        }
        public void Handle(UpdateDestinationCommand command) 
        {
            var destination = _context.Destinations.Find(command.Id);
            destination.City = command.City;
            destination.Price = command.Price;
            destination.DayNight= command.DayNight;           
            _context.SaveChanges();
            
        }
    }
}
