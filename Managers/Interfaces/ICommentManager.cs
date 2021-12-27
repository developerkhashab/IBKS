using IBKS.Context.Entities;

namespace IBKS.Managers.Interfaces
{
    public interface ICommentManager : IBaseManager<Comment>
    {
        void DeleteCommentsByPostId(int postId);
    }
}
