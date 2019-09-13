using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MartinsExquizite.Web.Startup))]
namespace MartinsExquizite.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
