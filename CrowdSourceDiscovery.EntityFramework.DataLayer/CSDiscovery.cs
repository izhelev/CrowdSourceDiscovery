using System.Data.Entity;
using CrowdSourceDiscovery.EntityFramework.DataLayer.EntityObjects;

namespace CrowdSourceDiscovery.EntityFramework.DataLayer
{
    public class CSDiscoveryContext : DbContext
    {
       public DbSet<Link> Links { get; set; }
       public DbSet<Comment> Comments { get; set; }
       public DbSet<Connection> Connections { get; set; }
    }
}
