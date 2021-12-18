using IBKS.Context.Entities;
using IBKS.Managers.Interfaces;

namespace IBKS.Controllers
{
    public class PostController : BaseController<Post>
    {
        private readonly IPostManager _postManager;
        public PostController(IPostManager postManager)
        {
            _postManager = postManager;
        }
        protected override IBaseManager<Post> GetManager()
        {
            return _postManager;
        }
    }
}
