using System;

namespace CrowdSourceDiscovery.EntityFramework.DataLayer.EntityObjects
{
    public class Comment
    {
        public Comment()
        {
            
        }

        public Comment(int connectionId, string text, Guid userId)
        {
            ConnectionId = connectionId;
            Text = text;
            UserId = userId;
        }

        public int Id { get; set; }
        public int ConnectionId { get; set; }
        public string Text { get; set; }
        public virtual Connection Connection
        {
            get; set;
        }

        public Guid UserId { get; set; }
    }
}
