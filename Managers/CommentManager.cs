using IBKS.Context.Entities;
using IBKS.DataAccess.Interfaces;
using IBKS.Managers.Infrastructure;
using IBKS.Managers.Interfaces;
using System.Linq;

namespace IBKS.Managers
{
    public class CommentManager : BaseManager<Comment>, ICommentManager
    {
        public CommentManager(ICommentRepository commentRepository) : base(commentRepository)
        {
        }

        public void DeleteCommentsByPostId(int postId)
        {
            var commentsId = IQueryable(x => x.PostId == postId).Select(x => x.Id).ToList();
            Delete(commentsId);
        }
    }
}
