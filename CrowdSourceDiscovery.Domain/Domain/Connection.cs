using System;
using System.Collections.Generic;

namespace CrowdSourceDiscovery.Domain
{
    public class Connection
    {
        public int Id { get; set; }
        public IList<Link> Links { get; set; }
        public List<Comment> Comments { get; set; }

        public Link GetFirstLink()
        {
            if (Links.Count < 2)
            {
                throw new ArgumentOutOfRangeException("Invalid number of links");
            }
            return Links[0];
        }

        public Link GetSecondLink()
        {
            if (Links.Count < 2)
            {
                throw new ArgumentOutOfRangeException("Invalid number of links");
            }
            return Links[1];
        }

    }
}
