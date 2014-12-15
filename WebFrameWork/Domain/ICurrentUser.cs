using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MVC.Template.Web.Models;

namespace MVC.Template.Web.Framework
{
    public interface ICurrentUser
    {
        ApplicationUser User { get; }
    }
}