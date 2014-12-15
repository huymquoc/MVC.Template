using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using MVC.Template.Web.Framework;
using MVC.Template.Web.Models;

namespace MVC.Template.Web.Domain
{
    public class LogAction
    {

        public LogAction(ApplicationUser user, string controllerName, string actionName, string description)
        {
            PerformedBy = user;
            ControllerName = controllerName;
            ActionName = actionName;
            Description = description;
            Time = DateTime.Now;

        }

        [Key]
        public int LogActionId { get; set; }

        public ApplicationUser PerformedBy { get; set; }

        public string ActionName { get; set; }

        public string ControllerName { get; set; }
        public DateTime PerformAt { get; set; }
        //public ApplicationUser PerformBy { get; set; }
        public string Description { get; set; }

        public DateTime Time { get; set; }

    }
}