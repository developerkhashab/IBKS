using IBKS.Context.Entities;
using IBKS.DataAccess.Interfaces;
using IBKS.Managers.Infrastructure;
using IBKS.Managers.Interfaces;

namespace IBKS.Managers
{
    public class PostManager : BaseManager<Post>, IPostManager
    {
        private readonly IPostRepository _postRepository;
        public PostManager(IPostRepository postRepository) : base(postRepository)
        {
            _postRepository = postRepository;
        }

        public dynamic test()
        {
            return _postRepository.testme();
        }

    }
}
