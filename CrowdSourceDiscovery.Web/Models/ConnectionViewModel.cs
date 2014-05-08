using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration.Conventions;
using CrowdSourceDiscovery.Domain;

namespace CrowdSourceDiscovery.Web.Models
{
    public class ConnectionViewModel
    {

        public int Id { get; set; }
        public string LinkOne { get; set; }
        public string LinkTwo { get; set; }
        public IList<Comment> Comments { get; set; }
    }
}