using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations.Design;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using StructureMap;
using StructureMap.Graph;
using MVC.Template.Web.Domain;
using StructureMap.Configuration.DSL;
using StructureMap.Configuration.DSL.Expressions;
using MVC.Template.Web.Framework;

namespace MVC.Template.Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        public IContainer Container
        {
            get { return (IContainer) HttpContext.Current.Items["_Container"]; }
            set { HttpContext.Current.Items["_Container"] = value; }
        }

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            DependencyResolver.SetResolver(new StructureMapDependencyResolver(()=> Container ?? ObjectFactory.Container));

            ObjectFactory.Configure(cfg =>
            {
                cfg.Scan(
                    scan =>
                    {
                        scan.TheCallingAssembly();
                        scan.WithDefaultConventions();
                        scan.AssembliesFromApplicationBaseDirectory();
                        //scan.AddAllTypesOf<IEntitityRepository>();
                        //scan.AddAllTypesOf<IIssueRepo>();
                        //scan.AddAllTypesOf<ILoggingRepo>();
                        //scan.AddAllTypesOf<IWorkingService>();
                        //scan.AddAllTypesOf<ILoggingService>();
                        scan.With(new ControllerConvention());
                    }
                    );

                cfg.For<DbContext>().Use(() => new FrameWorkDbContext());

                cfg.AddRegistry(new ActionFilterRegistry(() => Container ?? ObjectFactory.Container));
                //cfg.SetAllProperties(x => x.Matching(p => p.DeclaringType.CanBeCastTo(typeof(ActionFilterAttribute))
                //                      && p.DeclaringType.NameSpace.StartWith("MVC")
                //                      && !p.PropertyType.IsPrimitive && p.PropertyType != typeof(string)));
            } );
          
        }

        public void Application_BeginRequest()
        {
            Container = ObjectFactory.Container.GetNestedContainer();
        }

        public void Application_EndRequest()
        {
            Container.Dispose();
            Container = null;
        }
    }
}
