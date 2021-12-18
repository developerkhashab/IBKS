using IBKS.Context.Entities;
using IBKS.DataAccess.Interfaces;
using IBKS.Managers.Infrastructure;
using IBKS.Managers.Interfaces;

namespace IBKS.Managers
{
    public class CommentManager : BaseManager<Comment>, ICommentManager
    {
        public CommentManager(ICommentRepository commentRepository) : base(commentRepository)
        {

        }
    }
}
