using IBKS.Context;
using IBKS.Context.Entities;
using IBKS.DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace IBKS.DataAccess
{
    public class CommentRepository : BaseRepository<Comment>, ICommentRepository
    {
        public CommentRepository(DBContext context) : base(context)
        {
        }

        public override Expression<Func<Comment, object>>[] EntityIncludes()
        {
            var includes = new List<Expression<Func<Comment, object>>>();
            includes.Add(c => c.Post);
            includes.Add(c => c.User);

            return includes.ToArray();
        }

    }
}
