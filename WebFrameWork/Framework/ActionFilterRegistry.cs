using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC.Template.Web.Framework;
using StructureMap;
using StructureMap.Configuration.DSL;
using StructureMap.TypeRules;

namespace MVC.Template.Web.Framework
{
    public class ActionFilterRegistry : Registry
    {
        public ActionFilterRegistry(Func<IContainer> container)
        {
            For<IFilterProvider>().Use(new StructureMapFilterProvider(container));

            Policies.SetAllProperties(x => x.Matching(p => p.DeclaringType.CanBeCastTo(typeof(ActionFilterAttribute))
                                      && p.DeclaringType.Namespace.StartsWith("MVC")
                                      && !p.PropertyType.IsPrimitive && p.PropertyType != typeof(string)));

        }

    }
}