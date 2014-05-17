using System;
using System.Collections.Generic;
using System.Linq;

namespace CrowdSourceDiscovery.Domain
{
    public class Connection
    {
        public int Id { get; set; }
        public IList<Link> Links { get; set; }
        public IList<Comment> Comments { get; set; }

        public Guid UserId { get; set; }

        public Connection()
        {
            Comments = new List<Comment>();  
            Links = new List<Link>();
       }

        public Link GetFirstLink()
        {
            if (Links.Count < 2)
            {
                throw new ArgumentOutOfRangeException("Invalid number of links");
            }
            return Links[0];
        }

        public void UpdateFirstLink(Link link)
        {
            UpdateLinkWithLink(link, GetFirstLink());
        }

        public Link GetSecondLink()
        {
            if (Links.Count < 2)
            {
                throw new ArgumentOutOfRangeException("Invalid number of links");
            }
            return Links[1];
        }

        public void UpdateSecondLink(Link link)
        {
            UpdateLinkWithLink(link, GetSecondLink());
        }

        private void UpdateLinkWithLink(Link newLink, Link existingLink)
        {
            existingLink.Url = newLink.Url;
            existingLink.Title = newLink.Title;
        }

        public void AddComment(Comment comment)
        {
            Comments.Add(comment);
        }

        public void AddLinks(Link link)
        {
            Links.Add(link);
        }

        public Comment GetOriginalComment()
        {
            var comment = Comments.FirstOrDefault();
            if (comment == null)
            {
                throw new ArgumentOutOfRangeException("Orignal Comment not found");
            }

            return comment;
        }

        public void SaveOriginalComment(string text)
        {
            var comment = GetOriginalComment();
            comment.Text = text;
        }

    }
}
