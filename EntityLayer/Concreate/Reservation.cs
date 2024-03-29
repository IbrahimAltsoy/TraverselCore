﻿using static EntityLayer.Concreate.EnumStatu;

namespace EntityLayer.Concreate
{
    public class Reservation :IEntity
    {
        public Guid Id { get; set; }
        public int PersonCount { get; set; }
        //public string Destination { get; set; }
        public DateTime ReservationDate { get; set; }
        public string DEscription { get; set; }
         public StatuDurumu? Status { get; set; }
       
        public Guid AppUserId { get; set; }
        public Guid DestinationId { get; set; }
        
        public AppUser appUser { get; set; }
        public Destination Destination { get; set; }

        
    }
    
}
