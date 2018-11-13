using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Identity.WebUi.Startup))]
namespace Identity.WebUi
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
