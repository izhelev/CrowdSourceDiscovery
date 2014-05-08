namespace CrowdSourceDiscovery.Domain
{
    public class Comment
    {
        public int Id { get; set; }
        public int ConnectionId { get; set; }
        public string Text { get; set; }

        public Comment(string text)
        {
            Text = text;
        }

        public Comment()
        {
            
        }
    }
}