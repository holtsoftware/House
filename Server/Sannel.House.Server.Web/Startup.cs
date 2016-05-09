using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Sannel.House.Server.Web.Startup))]
namespace Sannel.House.Server.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
