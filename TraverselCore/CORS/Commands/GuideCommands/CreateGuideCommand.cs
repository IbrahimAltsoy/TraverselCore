using MediatR;

namespace TraverselCore.CORS.Commands.GuideCommands
{
    public class CreateGuideCommand:IRequest
    {       
        public string Name { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public string TwitterUrl { get; set; }
        public string InstagramUrl { get; set; }
        public bool Statu { get; set; }
    }
}
