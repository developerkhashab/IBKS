using IBKS.Context;
using IBKS.Context.Entities;
using IBKS.DataAccess;
using IBKS.Managers.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace IBKS.Controllers
{
    public class TestController : BaseController<User>
    {
        private readonly IUserManager _userManager;
        private readonly DBContext _context;
        public TestController(IUserManager userManager, DBContext context)
        {
            _userManager = userManager;
            _context = context;
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
    }
}
