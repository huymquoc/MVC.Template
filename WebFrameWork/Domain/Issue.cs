using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC.Template.Web.Domain
{
    public class Issue
    {

        [Key]
        public int IssueId { get; set; }
        public string Description { get; set; }

    }
}