using DataAccessLayer;
using EntityLayer.Concreate;
using MediatR;
using TraverselCore.CORS.Commands.GuideCommands;

namespace TraverselCore.CORS.Handlers.GuideHandlers
{
    public class CreateGuideCommandHandler : IRequestHandler<CreateGuideCommand>
    {
        private readonly Context _context;

        public CreateGuideCommandHandler(Context context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(CreateGuideCommand request, CancellationToken cancellationToken)
        {
            _context.Guides.Add(new Guide
            {
                Name= request.Name,
                Description= request.Description,
                Image =request.Image,
                TwitterUrl=request.TwitterUrl,
                InstagramUrl=request.InstagramUrl,
                Statu = true


            });
            await _context.SaveChangesAsync();
            return Unit.Value;
        }
    }
}
