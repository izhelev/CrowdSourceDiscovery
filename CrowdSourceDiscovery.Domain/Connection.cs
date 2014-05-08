using System;
using System.Collections.Generic;
using System.Linq;

namespace CrowdSourceDiscovery.Domain.Domain
{
    public class Connection
    {
        public int Id { get; set; }
        public IList<Link> Links { get; set; }
        public IList<Comment> Comments { get; set; }

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
            var firstLink = GetFirstLink();
            firstLink.Url = link.Url;
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
            var secondLink = GetSecondLink();
            secondLink.Url = link.Url;
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
