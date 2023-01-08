using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concreate
{
    public class Reservation :IEntity
    {
        public Guid Id { get; set; }
        public int PersonCount { get; set; }
        public string Destination { get; set; }
        public DateTime ReservationDate { get; set; }
        public string DEscription { get; set; }
        public string Status { get; set; }
       
        public Guid AppUserId { get; set; }
        public AppUser appUser { get; set; }

    }
}
