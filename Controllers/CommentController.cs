using IBKS.Context.Entities;
using IBKS.Managers.Interfaces;

namespace IBKS.Controllers
{
    public class CommentController : BaseController<Comment>
    {
        private readonly ICommentManager _commentManager;
        public CommentController(ICommentManager commentManager)
        {
            _commentManager = commentManager;
        }
        protected override IBaseManager<Comment> GetManager()
        {
            return _commentManager;
        }
    }
}
