using IBKS.Context.Entities;
using IBKS.DataAccess.Interfaces;
using IBKS.Managers.Infrastructure;
using IBKS.Managers.Interfaces;
using System;
using System.Linq;

namespace IBKS.Managers
{
    public class UserManager : BaseManager<User>, IUserManager
    {
        private readonly IPostManager _postManager;
        public UserManager(IUserRepository userRepository, IPostManager postManager) : base(userRepository)
        {
            _postManager = postManager;
        }
        public override void PreSaveInternal(User model)
        {
            if (model.DOB == null)
            {
                model.DOB = DateTime.UtcNow;
            }
            base.PreSaveInternal(model);
        }

        public override void Delete(int userId)
        {
            var record = GetById(userId);

            if (record == null)
            {
                throw new NullReferenceException("Record is not found");
            }

            _postManager.DeletePostsByUserId(userId);
            
            base.Delete(userId);
        }
    }
}
