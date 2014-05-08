using System;

namespace CrowdSourceDiscovery.Domain
{
    public class Link 
    {
        public int Id { get; set; }
        public int ConnectionId { get; set; }
        public Uri Url { get; set; }

        public Link()
        {
            
        }

        public Link(string url)
        {
            Url = new Uri(url);
        }

        public Link(Uri url)
        {
            Url = url;
        }
    }
}
