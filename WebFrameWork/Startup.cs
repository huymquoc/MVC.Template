using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MVC.Template.Web.Startup))]
namespace MVC.Template.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
