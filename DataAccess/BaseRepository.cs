using IBKS.Context;
using IBKS.DataAccess.Interfaces;
using IBKS.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace IBKS.DataAccess
{
    public class BaseRepository<TModel> : IBaseRepository<TModel> where TModel : ApiModel
    {
        private readonly DBContext _context;
        protected BaseRepository(DBContext context)
        {
            _context = context;
        }
        public virtual void Delete(TModel model)
        {
            Delete(model.Id);
        }

        public virtual void Delete(List<int> ids)
        {
            foreach (var id in ids)
            {
                Delete(id);
            }
        }

        public virtual void Delete(int id)
        {
            var record = GetT(id);
            if (record == null)
            {
                throw new NullReferenceException("Record is not found");
            }
            record.LastModified = DateTime.UtcNow;
            record.IsRemoved = true;
            var entity = _context.Set<TModel>().Update(record);
            _context.SaveChanges();
        }

        public virtual List<TModel> GetAll()
        {
            return _context.Set<TModel>().Where(x => !x.IsRemoved).ToList();
        }

        public virtual TModel GetT(int id)
        {
            return _context.Set<TModel>().FirstOrDefault(x => x.Id == id && !x.IsRemoved);
        }

        public virtual Expression<Func<TModel, object>>[] EntityIncludes()
        {
            return null;
        }

        public virtual TModel GetTTTTTT(int id)
        {
            var includes = typeof(TModel).GetProperties()
                     .Where(p => (typeof(IEnumerable).IsAssignableFrom(p.PropertyType) && p.PropertyType != typeof(string)) || p.PropertyType.Namespace == typeof(TModel).Namespace)
                     .Select(x => x.PropertyType)
                     .ToArray();
            return _context.Set<TModel>().IncludeMultiple(EntityIncludes()).FirstOrDefault(x => x.Id == id && !x.IsRemoved);
        }

        public virtual TModel Insert(TModel model)
        {
            var entity = _context.Set<TModel>().Add(model);
            model.CreatedDate = DateTime.UtcNow;
            model.LastModified = DateTime.UtcNow;
            _context.SaveChanges();
            return entity.Entity;
        }

        public virtual TModel Update(TModel model)
        {
            var record = _context.Set<TModel>().AsNoTracking().FirstOrDefault(x => x.Id == model.Id && !x.IsRemoved);
            if (record == null)
            {
                throw new NullReferenceException("Record is not found");
            }
            model.LastModified = DateTime.UtcNow;
            var entity = _context.Set<TModel>().Update(model);
            _context.SaveChanges();
            return entity.Entity;
        }

        public List<TModel> IQueryable(Expression<Func<TModel, bool>> expression)
        {
            return _context.Set<TModel>().Where(expression).Where(x => !x.IsRemoved).ToList();
        }

        public virtual IQueryable<T> IncludeMultiple<T>(IQueryable<T> query, params Expression<Func<T, object>>[] includes)where T : ApiModel
        {
            if (includes != null)
            {
                query = includes.Aggregate(query, (current, include) => current.Include(include));
            }

            return query;
        }
    }
}
