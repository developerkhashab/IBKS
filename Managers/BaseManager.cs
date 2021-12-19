using IBKS.DataAccess.Interfaces;
using IBKS.Managers.Interfaces;
using IBKS.Models;
using System.Collections.Generic;

namespace IBKS.Managers.Infrastructure
{
    public abstract class BaseManager<TModel> : IBaseManager<TModel> where TModel : ApiModel
    {
        #region Private Readonly

        private readonly IBaseRepository<TModel> _repository;

        #endregion

        #region Constructor        
        protected BaseManager(IBaseRepository<TModel> repository)
        {
            _repository = repository;
        }
        #endregion

        #region Public Methods

        public virtual TModel GetById(int id)
        {
            var model = _repository.GetT(id);
            model = LoadAdditionalInfo(model);
            return model;
        }

        public virtual List<TModel> GetAll()
        {
            var models = _repository.GetAll();
            foreach (var model in models)
            {
                LoadAdditionalInfo(model);
            }
            return models;
        }

        public virtual TModel LoadAdditionalInfo(TModel model)
        {
            return model;
        }

        public virtual bool DoModelExtraValidation(TModel model, out List<string> errors)
        {
            errors = new List<string>();
            return true;
        }

        public TModel Save(TModel item, bool doValidation = false)
        {
            PreSaveInternal(item);
            var isNew = item.Id == 0;
            var newModel = isNew ? Insert(item, doValidation) : Update(item, doValidation);
            return newModel;
        }

        public TModel Insert(TModel item, bool doValidation = false)
        {
            List<string> errors;
            DoModelExtraValidation(item, out errors);
            var model = InsertInternal(item);

            return model;
        }

        public TModel Update(TModel item, bool doValidation = false)
        {

            var model = _repository.Update(item);

            return model;
        }

        public virtual void Delete(int id)
        {
            _repository.Delete(id);
        }

        public virtual void PreSaveInternal(TModel model) { }

        #endregion

        #region Protected Methods
        protected virtual TModel InsertInternal(TModel item)
        {
            var model = _repository.Insert(item);
            return model;
        }

        protected virtual TModel UpdateInternal(TModel item)
        {
            var model = _repository.Update(item);
            return model;
        }
        #endregion
    }
}

