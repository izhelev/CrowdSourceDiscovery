using System.Collections.Generic;

namespace CrowdSourceDiscovery.EntityFramework.DataLayer.EntityObjects
{
    public class Connection
    {
        public Connection()
        {
            
        }

        public int Id { get; set; }
        public virtual IList<Comment> Comments { get; set; }
        public virtual IList<Link> Links { get; set; }
    }
}
