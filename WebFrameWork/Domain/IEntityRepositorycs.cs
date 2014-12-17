using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace MVC.Template.Web.Domain
{
    public interface IEntitityRepository<T> where T : class
    {
        IQueryable<T> GetAll();

        IQueryable<T> GetAll(params Expression<Func<T, object>>[] navProperties);
        void Add(params T[] entities);
        T Get(Expression<Func<T, bool>> expression);
        void Delete(T entity);
        void Edit(T entity);
        IQueryable<T> Find(Expression<Func<T, bool>> expression);
        void Save();
    }
}