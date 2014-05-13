using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace CrowdSourceDiscovery.Web.Models
{
    public class ConnectionFormModel
    {
        public int ConnectionId { get; set; }

        [Required]
        [Display(Name = "Url")]
        [DataType(DataType.Url)]
        public string LinkOne { get; set; }

        [Required]
        [Display(Name = "Url")]
        [DataType(DataType.Url)]
        public string LinkTwo { get; set; }

        [Required]
        [Display(Name="Comment")]
        public string Comment { get; set; }
    }
}