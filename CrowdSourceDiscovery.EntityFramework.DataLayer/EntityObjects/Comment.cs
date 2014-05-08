using System.ComponentModel.DataAnnotations.Schema;

namespace CrowdSourceDiscovery.EntityFramework.DataLayer.EntityObjects
{
    public class Comment
    {
        public Comment()
        {
            
        }

        public Comment(int connectionId, string text)
        {
            ConnectionId = connectionId;
            Text = text;
        }

        public int Id { get; set; }
        public int ConnectionId { get; set; }
        public string Text { get; set; }
        public virtual Connection Connection
        {
            get; set;
        }
    }
}
