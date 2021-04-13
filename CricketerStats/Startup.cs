using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CricketerStats.Startup))]
namespace CricketerStats
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
