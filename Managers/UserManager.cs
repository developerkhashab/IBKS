using IBKS.Context.Entities;
using IBKS.DataAccess.Interfaces;
using IBKS.Managers.Infrastructure;
using IBKS.Managers.Interfaces;

namespace IBKS.Managers
{
    public class UserManager : BaseManager<User>, IUserManager
    {
        public UserManager(IUserRepository userRepository) : base(userRepository)
        {

        }
    }
}
