using IBKS.Context;
using IBKS.Context.Entities;
using IBKS.DataAccess;
using IBKS.Managers.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace IBKS.Controllers
{
    public class ThirdPartyController : Controller
    {
        private readonly DBContext _context;
        public ThirdPartyController(DBContext context)
        {
            _context = context;
        }

        [HttpGet("Posts")]
        public virtual List<Post> GetALLPosts()
        {
            return _context.Posts.IncludeMultiple(c => c.Comments).ToList();
        }

        [HttpGet("Users")]
        public virtual List<User> GetALLUsers()
        {
            return _context.Users.ToList();
        }

        [HttpGet("Comments")]
        public virtual List<Comment> GetALLComments()
        {
            return _context.Comments.IncludeMultiple(c => c.Post).ToList();
        }
    }
}
