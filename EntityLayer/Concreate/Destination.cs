using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concreate
{
    public class Destination:IEntity
    {
        public Guid Id { get; set; }
        public string City { get; set; }
        public string DayNight { get; set; }
        public double Price { get; set; }
        public string Image { get; set; }
        public string Description { get; set; }
        public int Capacity { get; set; }
        public bool Statu { get; set; }

        public string CoverImage { get; set; }
        public string DetailsOne { get; set; }
        public string DetailsTwo { get; set; }
        public string ImageTwo { get; set; }
    }
}
