using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CarDealershipTake3.Startup))]
namespace CarDealershipTake3
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
