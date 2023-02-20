using DataAccessLayer;
using TraverselCore.CORS.Commands.DestinationCommands;

namespace TraverselCore.CORS.Handlers.DestinationHandlers
{
    public class CreateDestinationCommandHandler
    {
        private readonly Context _context;

        public CreateDestinationCommandHandler(Context context)
        {
            _context = context;
        }
        public void Handle(CreateDestinationCommand createDestinationCommand)
        {
            _context.Destinations.Add(new EntityLayer.Concreate.Destination
            {
                City= createDestinationCommand.City,
                DayNight= createDestinationCommand.DayNight,
                Price= createDestinationCommand.Price,
                Statu = true,
                Capacity= createDestinationCommand.Capacity
            });
            _context.SaveChanges();
        }
    }
}
