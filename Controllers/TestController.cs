using IBKS.Context;
using IBKS.Context.Entities;
using IBKS.DataAccess;
using IBKS.DataAccess.Interfaces;
using IBKS.Managers.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace IBKS.Controllers
{
    public class TestController : BaseController<User>
    {
        private readonly IUserManager _userManager;
        private readonly IPostRepository _postRepository;
        private readonly DBContext _context;
        public TestController(IUserManager userManager, DBContext context, IPostRepository postRepository)
        {
            _userManager = userManager;
            _context = context;
            _postRepository = postRepository;
        }
        protected override IBaseManager<User> GetManager()
        {
            return _userManager;
        }

        [HttpGet("getall")]
        public virtual IEnumerable<dynamic> GetALL()
        {
            return _context.Users.IncludeMultiple(c => c.Posts);
        }

        [HttpGet("getme")]
        public virtual dynamic GetMe()
        {
            return _postRepository.GetTTTTTT(21);
        }
    }
}
