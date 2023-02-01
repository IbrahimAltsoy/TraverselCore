using EntityLayer.Concreate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public interface IContactUsRepository : IRepository<ContactUs>
    {
        Task<IEnumerable<ContactUs>> GetByMessageIsDeletedFalse();
        Task<IEnumerable<ContactUs>> GetByMessageIsDeletedTrue();
        Task<ContactUs> ChangesMessageStatuWithContactUs(Guid id);
    }
}
