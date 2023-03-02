﻿using BusiinessLayer;
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
           // return await context.Products.Include(c => c.Category).Include(b => b.Brand).ToListAsync();
        }
        
    }
}
