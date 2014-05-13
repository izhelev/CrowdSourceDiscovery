using System;

namespace CrowdSourceDiscovery.Contracts.Dtos.Dto
{
    public class CommentDto
    {
        public int Id;
        public int ConnectionId { get; set; }
        public string Text { get; set; }
        public Guid UserId { get; set; }
    }
}