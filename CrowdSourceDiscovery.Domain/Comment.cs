using System;

namespace CrowdSourceDiscovery.Domain
{
    public class Comment
    {
        public int Id { get; set; }
        public int ConnectionId { get; set; }
        public string Text { get; set; }

        public Guid UserId { get; set; }

        public Comment(string text, Guid userId)
        {
            Text = text;
            UserId = userId;
        }

        public Comment()
        {
            
        }
    }
}