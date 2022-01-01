using IBKS.Context.Entities;
using IBKS.DataAccess.Interfaces;
using IBKS.Managers.Infrastructure;
using IBKS.Managers.Interfaces;
using System.Linq;

namespace IBKS.Managers
{
    public class PostManager : BaseManager<Post>, IPostManager
    {
        private readonly ICommentManager _commentManager;
        public PostManager(IPostRepository postRepository, ICommentManager commentManager) : base(postRepository)
        {
            _commentManager = commentManager;
        }

        public override void Delete(int postId)
        {
            _commentManager.DeleteCommentsByPostId(postId);
            base.Delete(postId);
        }

        public void DeletePostsByUserId(int userId)
        {
            var posts = IQueryable(x => x.UserId == userId).Select(x => x.Id).ToList();
            foreach (var post in posts)
            {
                Delete(post);
            }
        }
    }
}
