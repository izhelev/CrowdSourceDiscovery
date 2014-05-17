using System.ComponentModel.DataAnnotations;

namespace CrowdSourceDiscovery.Web.Models
{
    public class ConnectionListModel
    {
        public int ConnectionId { get; set; }

        [Display(Name="First article")]
        public string LinkOneTitle { get; set; }

        [Display(Name = "Second article")]
        public string LinkTwoTitle { get; set; }

        [Display(Name="Activity")]
        public int NumberOfComments { get; set; }
    }
}