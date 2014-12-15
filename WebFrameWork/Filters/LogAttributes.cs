using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC.Template.Web.Models;
using MVC.Template.Web.Framework;
using MVC.Template.Web.Domain;

namespace MVC.Template.Web.Filters
{
    public class LogAttribute : ActionFilterAttribute
    {
        public IDictionary<string,object> _parameters { get; set; }

        public ApplicationDbContext Context { get; set; }

        public ILoggingService Logger { get; set; }
        public ICurrentUser CurrentUser { get; set; }
        public string Description { get; set; }
        public LogAttribute(string description)
        {
            Description = description;
        }

        public override void OnActionExecuting(System.Web.Mvc.ActionExecutingContext filterContext)
        {
            _parameters = filterContext.ActionParameters;
            base.OnActionExecuting(filterContext);

        }

        public override void OnActionExecuted(System.Web.Mvc.ActionExecutedContext filterContext)
        {
            var description = Description;
            foreach(var k in _parameters)
            {
                description = description.Replace("{" + k.Key + "}", k.Value.ToString());
            }
            Logger.Logging(CurrentUser.User, filterContext.ActionDescriptor.ControllerDescriptor.ControllerName, 
                                filterContext.ActionDescriptor.ActionName, description);


        }

 
    }
}