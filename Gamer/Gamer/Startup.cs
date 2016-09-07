using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Gamer.Startup))]
namespace Gamer
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
