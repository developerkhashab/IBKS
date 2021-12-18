using IBKS.Context;
using IBKS.Context.Entities;
using IBKS.DataAccess.Interfaces;

namespace IBKS.DataAccess
{
    public class CommentRepository : BaseRepository<Comment>, ICommentRepository
    {
        public CommentRepository(DBContext context) : base(context)
        {
        }
    }
}
