namespace CrowdSourceDiscovery.EntityFramework.DataLayer.EntityObjects
{
    public class Link
    {

        public Link(int connectionId, string url)
        {
            ConnectionId = connectionId;
            Url = url;
        }

        public int Id { get; set; }
        public int ConnectionId { get; set; }
        public string Url { get; set; }

        public virtual Connection Connection { get; set; }

    }
}
