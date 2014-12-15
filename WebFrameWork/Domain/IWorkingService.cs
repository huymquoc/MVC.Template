using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MVC.Template.Web.Domain;

namespace MVC.Template.Web.Domain
{
    public interface IWorkingService
    {
        void InsertIssue(Issue issue);
        //void RemoveIssue(int issueId);

        IQueryable<Issue> GetAllIssues();
    }


    
    public class WorkingService : IWorkingService
    {

        private readonly IIssueRepo _issue;

        public WorkingService(IIssueRepo iss)
        {
            _issue = iss;
        }

        public IQueryable<Issue> GetAllIssues()
        {
            return _issue.GetAll();
        }
        public void InsertIssue(Issue issue)
        {
            _issue.Add(issue);
            _issue.Save();

        }

        //public void RemoveIssue(int issueId)
        //{
        //    var issue = _context.Issues.SingleOrDefault(c => c.IssueId == issueId);
        //    if (issue != null)
        //    {
        //        _context.Issues.Remove(issue);
        //        _context.SaveChanges();

        //    }
        //}
    }

    
}