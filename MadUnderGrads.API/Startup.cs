using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(MadUnderGrads.API.Startup))]

namespace MadUnderGrads.API
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);

        }
    }
}
