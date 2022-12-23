using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concreate
{
    public class About :IEntity
    {
        public Guid Id { get; set; }
        public string TitleOne { get; set; }
        public string Description { get; set; }
        public string TitleTwo { get; set; }
        public string DescriptionTwo { get; set; }
        public string Image { get; set; }    
        public bool Statu { get; set; }

    }
}
