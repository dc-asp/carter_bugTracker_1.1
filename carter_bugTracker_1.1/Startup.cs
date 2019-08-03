using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(carter_bugTracker_1._1.Startup))]
namespace carter_bugTracker_1._1
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
