using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Services.Description;
using Microsoft.Win32;
using StructureMap;
using StructureMap.Graph;
using StructureMap.Pipeline;
using StructureMap.TypeRules;

namespace MVC.Template.Web.Framework
{
    public class StructureMapDependencyResolver : IDependencyResolver
    {
        private Func<IContainer> _containerFactory;

        public StructureMapDependencyResolver(Func<IContainer> containerFactory)
        {
            _containerFactory = containerFactory;
        }
        public object GetService(Type serviceType)
        {
            if (serviceType == null)
            {
                return null;
            }
            var container = _containerFactory();
            return serviceType.IsAbstract || serviceType.IsInterface
                ? container.TryGetInstance(serviceType)
                : container.GetInstance(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return _containerFactory().GetAllInstances(serviceType).Cast<object>();
        }
    }

    public class ControllerConvention : IRegistrationConvention
    {
       public void Process(Type type, StructureMap.Configuration.DSL.Registry registry)
        {
            if (type.CanBeCastTo(typeof(Controller)) && !type.IsAbstract)
            {
                registry.For(type).LifecycleIs(new UniquePerRequestLifecycle());
            }
        }
    }
}