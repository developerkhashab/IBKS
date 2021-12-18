using IBKS.Context;
using IBKS.Context.Entities;
using IBKS.DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IBKS.DataAccess
{
    public class PostRepository : BaseRepository<Post>, IPostRepository
    {
        private readonly DBContext _context;
        public PostRepository(DBContext context) : base(context)
        {
            _context = context;
        }



        public dynamic testme()
        {
            return _context.Users.Where(x => x.Id == 1).IncludeMultiple(c => c.Posts);
        }
    }
}
