using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Lab7_Identity.Startup))]
namespace Lab7_Identity
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
