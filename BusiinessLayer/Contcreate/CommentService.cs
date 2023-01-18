using BusiinessLayer.Abstract;
using DataAccessLayer;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concreate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusiinessLayer.Contcreate
{
    public class CommentService : CommentRepository,ICommentService
    {
        public CommentService(Context _context) : base(_context)
        {
        }
    }
}
