using System;

namespace CrowdSourceDiscovery.Domain
{
    public class Link 
    {
        public int Id { get; set; }
        public int ConnectionId { get; set; }
        public Uri Url { get; set; }
        public string Title { get; set; }

        public Link()
        {
            
        }

        public Link(string url, string title)
        {
            Url = new Uri(url);
            Title = title;
        }

        public Link(Uri url, string title)
        {
            Url = url;
            Title = title;
        }
    }
}
