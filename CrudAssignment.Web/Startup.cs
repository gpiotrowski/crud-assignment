using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CrudAssignment.Web.Startup))]
namespace CrudAssignment.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
