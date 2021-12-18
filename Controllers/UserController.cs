using IBKS.Context.Entities;
using IBKS.Managers.Interfaces;

namespace IBKS.Controllers
{
    public class UserController : BaseController<User>
    {
        private readonly IUserManager _userManager;
        public UserController(IUserManager userManager)
        {
            _userManager = userManager;
        }
        protected override IBaseManager<User> GetManager()
        {
            return _userManager;
        }
    }
}
