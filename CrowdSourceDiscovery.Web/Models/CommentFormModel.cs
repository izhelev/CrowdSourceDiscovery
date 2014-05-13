using System.ComponentModel.DataAnnotations;

namespace CrowdSourceDiscovery.Web.Models
{
    public class CommentFormModel
    {
        public int ConnectionId { get; set; }

        [Display(Name= "Comment")]
        [DataType(DataType.MultilineText)]
        public string Text { get; set; }
    }
}