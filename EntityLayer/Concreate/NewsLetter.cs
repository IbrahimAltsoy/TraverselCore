﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concreate
{
    public class NewsLetter:IEntity
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
    }
}
