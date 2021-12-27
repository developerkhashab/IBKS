using IBKS.Context.Entities;

namespace IBKS.Managers.Interfaces
{
    public interface IPostManager : IBaseManager<Post>
    {
        void DeletePostsByUserId(int userId);
    }
}
