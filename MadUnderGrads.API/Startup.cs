using Hangfire;
using Hangfire.SqlServer;
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

            var options = new SqlServerStorageOptions
            {
                PrepareSchemaIfNecessary = false
            };

            GlobalConfiguration.Configuration.UseSqlServerStorage("DefaultConnection", options);

            app.UseHangfireDashboard();
            app.UseHangfireServer();
        }
    }
}
