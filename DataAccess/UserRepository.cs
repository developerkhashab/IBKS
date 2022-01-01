using IBKS.Context;
using IBKS.Context.Entities;
using IBKS.DataAccess.Interfaces;
using System.Linq;

namespace IBKS.DataAccess
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        private readonly DBContext _context;
        public UserRepository(DBContext context) : base(context)
        {
            _context = context;
        }

        public override User GetT(int id)
        {
            return _context.Users.IncludeMultiple(c => c.Posts).FirstOrDefault(x => x.Id == id);
        }
    }
}
