using BusiinessLayer;
using BusiinessLayer.Abstract;
using BusiinessLayer.Concreate;
using EntityLayer.Concreate;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusiinessLayer.Concreate
{
    public class CommentRepository : Repository<Comment>, ICommentRepository
    {
        public CommentRepository(Context _context) : base(_context)
        {
        }
        public async Task<IEnumerable<Comment>> GetAllCommentWithDestinationAsync()
        {
            return await context.Comments.Include(d=>d.Destination).AsTracking().ToListAsync();
           
        }
        public async Task<List<Comment>> GetAllCommentWithDestinationAndUserAsync(Guid id)
        {
            return await context.Comments.Where(d => d.DestinationId == id).Include(d => d.AppUser).ToListAsync(); 
           
        }

    }
}
