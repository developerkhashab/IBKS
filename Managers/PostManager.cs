using IBKS.Context.Entities;
using IBKS.DataAccess.Interfaces;
using IBKS.Managers.Infrastructure;
using IBKS.Managers.Interfaces;
using System;
using System.Linq;

namespace IBKS.Managers
{
    public class PostManager : BaseManager<Post>, IPostManager
    {
        private readonly ICommentManager _commentManager;
        private readonly IUserManager _userManager;
        public PostManager(IPostRepository postRepository, ICommentManager commentManager, IUserManager userManager) : base(postRepository)
        {
            _commentManager = commentManager;
            _userManager = userManager;
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

        public override void PreSaveInternal(Post model)
        {
            var user = _userManager.GetById(model.UserId);
            if (user == null)
            {
                throw new NullReferenceException("user not found");
            }
            base.PreSaveInternal(model);
        }

    }
}
