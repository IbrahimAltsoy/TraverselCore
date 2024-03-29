﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concreate
{
    public class Comment : IEntity
    {
        public Guid Id { get; set; }
        public string User { get; set; }
        public DateTime DateTime { get; set; }
        public string Content { get; set; }
        public bool Status { get; set; }

        public Guid DestinationId { get; set; }

        public Destination Destination { get; set; }

        public Guid AppUserId { get; set; }

        public AppUser AppUser { get; set; }

    }
}
