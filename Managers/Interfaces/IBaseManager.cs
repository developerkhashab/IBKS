using IBKS.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace IBKS.Managers.Interfaces
{
    public interface IBaseManager<TModel> where TModel : ApiModel
    {
        TModel GetById(int id);
        List<TModel> GetAll();

        TModel LoadAdditionalInfo(TModel model);

        bool DoModelExtraValidation(TModel model, out List<string> errors);

        TModel Save(TModel item, bool doValidation = false);

        TModel Insert(TModel item, bool doValidation = false);

        TModel Update(TModel item, bool doValidation = false);

        void Delete(int id);

        List<TModel> IQueryable(Expression<Func<TModel, bool>> expression);

        void PreSaveInternal(TModel model);

        void Delete(List<int> ids);
    }
}
