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
        [Url(ErrorMessage = "Not a valid Url")]
        public string LinkOne { get; set; }

        [Required]
        [Display(Name = "Title")]
        [MaxLength(100, ErrorMessage = "Name cannot be longer than 100 characters.")]
        public string LinkOneTitle { get; set; }


        [Required]
        [Display(Name = "Url")]
        [DataType(DataType.Url)]
        [Url(ErrorMessage = "Not a valid Url")]
        public string LinkTwo { get; set; }

        [Required]
        [Display(Name = "Title")]
        [MaxLength(100, ErrorMessage = "Name cannot be longer than 100 characters.")]
        public string LinkTwoTitle { get; set; }


        [Required]
        [Display(Name="Comment")]
        public string Comment { get; set; }
    }
}