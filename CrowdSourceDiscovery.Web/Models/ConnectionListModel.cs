using System.ComponentModel.DataAnnotations;

namespace CrowdSourceDiscovery.Web.Models
{
    public class ConnectionListModel
    {
        public int ConnectionId { get; set; }

        [Display(Name="Article One")]
        public string LinkOne { get; set; }

        [Display(Name = "Article One")]
        public string LinkTwo { get; set; }

        public int NumberOfComments { get; set; }
    }
}