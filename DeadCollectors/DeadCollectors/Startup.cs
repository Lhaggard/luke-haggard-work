using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DeadCollectors.Startup))]
namespace DeadCollectors
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
