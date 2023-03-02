using BusiinessLayer.Abstract;
using EntityLayer.Concreate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusiinessLayer.Abstract
{
    public interface IService<T>: IRepository<T> where T : class, IEntity, new() 
    {
        
    }
    
}
