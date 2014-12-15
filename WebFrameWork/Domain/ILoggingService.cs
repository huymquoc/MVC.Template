using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MVC.Template.Web.Domain;
using MVC.Template.Web.Framework;
using MVC.Template.Web.Models;

namespace MVC.Template.Web.Domain
{
    public interface ILoggingService
    {
        void Logging(ApplicationUser user, string controllerName, string actionName, string description);
    }
    public class LoggingService : ILoggingService
    {
        private readonly ILoggingRepo _logging;
        public LoggingService(ILoggingRepo log)
        {
            _logging = log;
        }

        public void Logging(ApplicationUser user, string controllerName, string actionName, string description)
        {
            var log = new LogAction(user, controllerName, actionName, description);
            _logging.Add(log);
            _logging.Save();
        }
    }

    
}