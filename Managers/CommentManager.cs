using IBKS.Context.Entities;
using IBKS.DataAccess.Interfaces;
using IBKS.Managers.Infrastructure;
using IBKS.Managers.Interfaces;
using System;
using System.Linq;

namespace IBKS.Managers
{
    public class CommentManager : BaseManager<Comment>, ICommentManager
    {
        private readonly IPostManager _postManager;
        private readonly IUserManager _userManager;
        public CommentManager(ICommentRepository commentRepository, IPostManager postManager, IUserManager userManager) : base(commentRepository)
        {
            _postManager = postManager;
            _userManager = userManager;
        }

        public void DeleteCommentsByPostId(int postId)
        {
            var commentsId = IQueryable(x => x.PostId == postId).Select(x => x.Id).ToList();
            Delete(commentsId);
        }

        public override void PreSaveInternal(Comment model)
        {
            var post = _postManager.GetById(model.PostId);
            if (post == null)
            {
                throw new NullReferenceException("post is not found");
            }

            var user = _userManager.GetById(model.UserId);
            if (user == null)
            {
                throw new NullReferenceException("user is not found");
            }
            base.PreSaveInternal(model);
        }
    }
}
