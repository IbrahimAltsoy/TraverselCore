using BusiinessLayer.Abstract;
using EntityLayer.Concreate;
using Microsoft.EntityFrameworkCore;

namespace BusiinessLayer.Concreate
{
    public class ContactUsRepository : Repository<ContactUs>, IContactUsRepository
    {        
        public ContactUsRepository(Context _context) : base(_context)
        {

        }
        public async Task<IEnumerable<ContactUs>> GetByMessageIsDeletedFalse()
        {
            return await context.ContactUses.Where(m => m.IsDeleted==false).AsTracking().ToListAsync();
            
        }
        public async Task<IEnumerable<ContactUs>> GetByMessageIsDeletedTrue()
        {
            return await context.ContactUses.Where(m => m.IsDeleted ==true).AsTracking().ToListAsync();

        }
        //public async Task<IEnumerable<ContactUs>> ChangesMessageStatuWithContactUs()
        //{
        //    return await context.ContactUses.Where(m => m.IsDeleted == true).AsTracking().ToListAsync();

        //}
        public async Task<ContactUs> ChangesMessageStatuWithContactUs(Guid id)
        {
            var model = await context.ContactUses.FindAsync(id);
            if (model.IsDeleted == true)
            {
                model.IsDeleted = false;
            }
            else
            {
                model.IsDeleted = true;
            }
            await context.SaveChangesAsync();
            return model;

        }
    }
}
