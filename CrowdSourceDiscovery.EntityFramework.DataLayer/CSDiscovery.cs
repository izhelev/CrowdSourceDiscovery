using System.Data.Entity;
using CrowdSourceDiscovery.Contracts.Dtos;
using CrowdSourceDiscovery.EntityFramework.DataLayer.EntityObjects;
using Microsoft.AspNet.Identity.EntityFramework;

namespace CrowdSourceDiscovery.EntityFramework.DataLayer
{
    public class CSDiscoveryContext : IdentityDbContext<ApplicationUser>
    {
        public CSDiscoveryContext()
            : base("DefaultConnection")
        {
        }


        public DbSet<Link> Links { get; set; }
       public DbSet<Comment> Comments { get; set; }
       public DbSet<Connection> Connections { get; set; }
    }
}
