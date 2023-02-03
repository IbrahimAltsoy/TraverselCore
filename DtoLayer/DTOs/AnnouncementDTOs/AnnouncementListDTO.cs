using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DtoLayer.DTOs.AnnouncementDTOs
{
    public class AnnouncementListDTO
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
    }
}
