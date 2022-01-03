using IBKS.Context;
using IBKS.Context.Entities;
using IBKS.DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace IBKS.DataAccess
{
    public class PostRepository : BaseRepository<Post>, IPostRepository
    {
        private readonly DBContext _context;
        public PostRepository(DBContext context) : base(context)
        {
            _context = context;
        }

        public override Expression<Func<Post, object>>[] EntityIncludes()
        {
            var includes = new List<Expression<Func<Post, object>>>();
            includes.Add(c => c.Comments.Where(x => !x.IsRemoved));
            includes.Add(c => c.User);

            return includes.ToArray();
        }
    }
}
