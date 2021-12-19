using IBKS.Models;
using System.Collections.Generic;

namespace IBKS.DataAccess.Interfaces
{
    public interface IBaseRepository<TModel> where TModel : ApiModel
    {
        TModel GetT(int id);

        List<TModel> GetAll();

        TModel Update(TModel model);

        TModel Insert(TModel model);

        void Delete(TModel model);

        void Delete(int id);
    }
}
