using IBKS.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

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

        List<TModel> IQueryable(Expression<Func<TModel, bool>> expression);

        void Delete(List<int> ids);
    }
}
