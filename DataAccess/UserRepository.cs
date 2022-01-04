using IBKS.Context;
using IBKS.Context.Entities;
using IBKS.DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace IBKS.DataAccess
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(DBContext context) : base(context)
        {
        }

        public override Expression<Func<User, object>>[] EntityIncludes()
        {
            var includes = new List<Expression<Func<User, object>>>();
            includes.Add(c => c.Comments.Where(x => !x.IsRemoved));
            includes.Add(c => c.Posts.Where(x => !x.IsRemoved));

            return includes.ToArray();
        }
    }
}
