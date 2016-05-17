using Microsoft.Owin;
using Owin;

[assembly: OwinStartup("MVCapp", typeof(Webshop.Startup))]
namespace Webshop
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
