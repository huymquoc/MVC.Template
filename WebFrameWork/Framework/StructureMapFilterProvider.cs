using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using StructureMap;

namespace MVC.Template.Web.Framework
{
    public class StructureMapFilterProvider : FilterAttributeFilterProvider
    {

        private readonly Func<IContainer> _container;

        public StructureMapFilterProvider(Func<IContainer> container)
        {
            _container = container;
        }

        public override IEnumerable<System.Web.Mvc.Filter> GetFilters(ControllerContext controllerContext, ActionDescriptor actionDescriptor)
        {
            var filters = base.GetFilters(controllerContext, actionDescriptor);
            var container = _container();
            foreach(var filter in filters)
            {
                container.BuildUp(filter.Instance);
                yield return filter;
            }

        }
    }
}