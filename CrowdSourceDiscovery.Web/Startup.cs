using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using CrowdSourceDiscovery.EntityFramework.DataLayer;
using CrowdSourceDiscovery.EntityFramework.DataLayer.Migrations;
using CrowdSourceDiscovery.Web;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(Startup))]
namespace CrowdSourceDiscovery.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<CSDiscoveryContext, Configuration>());
        }
    }
}
