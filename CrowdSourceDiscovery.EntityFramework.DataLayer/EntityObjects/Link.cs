namespace CrowdSourceDiscovery.EntityFramework.DataLayer.EntityObjects
{
    public class Link
    {
        public Link()
        {         
        }

        public Link(int connectionId, string url, string title)
        {
            ConnectionId = connectionId;
            Url = url;
            Title = title;
        }

        public int Id { get; set; }
        public int ConnectionId { get; set; }
        public string Url { get; set; }
        public string Title { get; set; }

        public virtual Connection Connection { get; set; }

    }
}
