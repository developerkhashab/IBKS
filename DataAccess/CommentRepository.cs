using IBKS.Context;
using IBKS.Context.Entities;
using IBKS.DataAccess.Interfaces;
using System.Linq;

namespace IBKS.DataAccess
{
    public class CommentRepository : BaseRepository<Comment>, ICommentRepository
    {
        private readonly DBContext _context;
        public CommentRepository(DBContext context) : base(context)
        {
            _context = context;
        }

        public override Comment GetT(int id)
        {
            return _context.Comments.IncludeMultiple(c => c.Post).FirstOrDefault(x => x.Id == id);
        }
    }
}
