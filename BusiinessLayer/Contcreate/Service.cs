using BusiinessLayer.Abstract;
using BusiinessLayer;
using BusiinessLayer.Concreate;
using EntityLayer.Concreate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusiinessLayer.Contcreate
{
    public class Service<T>: Repository<T>, IService<T> where T: class, IEntity, new() 
    { 
        public Service(Context _context) : base(_context) 
        {

        }
    }
    
}
