using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using CrowdSourceDiscovery.Domain;

namespace CrowdSourceDiscovery.Web.Models
{
    public class ConnectionFormModel
    {      
        [Required]
        [Display(Name = "Link One")]
        public string LinkOne { get; set; }

        [Required]
        [Display(Name = "Link Two")]
        public string LinkTwo { get; set; }

        [Required]
        [Display(Name="Comment")]
        public string Comment { get; set; }
    }
}