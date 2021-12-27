using IBKS.Context;
using IBKS.Context.Entities;
using IBKS.DataAccess.Interfaces;
using System;

namespace IBKS.DataAccess
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(DBContext context) : base(context)
        {
        }
    }
}
