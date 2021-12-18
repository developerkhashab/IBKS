using IBKS.Context.Entities;

namespace IBKS.DataAccess.Interfaces
{
    public interface IPostRepository : IBaseRepository<Post>
    {
        dynamic testme();
    }
}
