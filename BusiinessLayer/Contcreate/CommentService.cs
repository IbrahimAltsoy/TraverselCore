using BusiinessLayer.Abstract;
using BusiinessLayer;
using BusiinessLayer.Abstract;
using BusiinessLayer.Concreate;
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
