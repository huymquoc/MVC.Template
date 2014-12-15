using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace MVC.Template.Web.Domain
{

    public interface IIssueRepo : IEntitityRepository<Issue> { }
   // public interface IEmailCampaignTriggerModelRepo : IEntitiesRepository<EmailCampaignTriggerModel> { }
    public interface ILoggingRepo : IEntitityRepository<LogAction> { }

    public class IssueRepo : EntitityRepository<Issue> , IIssueRepo
    {
        public IssueRepo(DbContext context) : base(context)
        {
        }
    }
        public class LoggingRepo : EntitityRepository<LogAction> , ILoggingRepo
        {
            public LoggingRepo(DbContext context) : base(context)
            {
            }
        }

    public class EntitityRepository<T> : IEntitityRepository<T> where T : class
    {
        private readonly DbContext _context;

        public EntitityRepository(DbContext context)
        {
            if (context == null)
                throw new ArgumentNullException("context");
            _context = context;
        }
        public IQueryable<T> GetAll()
        {
            return _context.Set<T>();
        }

        public void Add(T entity)
        {
            _context.Set<T>().Add(entity);
        }

        public T Get(Expression<Func<T, bool>> expression)
        {
            return _context.Set<T>().SingleOrDefault(expression);
        }

        public void Delete(T entity)
        {
            DbEntityEntry entry = _context.Entry(entity);
            entry.State = EntityState.Deleted;
        }

        public void Edit(T entity)
        {
            DbEntityEntry entry = _context.Entry(entity);
            entry.State = EntityState.Modified;
        }
        public IQueryable<T> Find(Expression<Func<T, bool>> expression)
        {
            return _context.Set<T>().Where(expression);
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}