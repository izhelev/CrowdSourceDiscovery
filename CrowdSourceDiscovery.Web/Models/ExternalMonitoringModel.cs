using System;

namespace CrowdSourceDiscovery.Web.Models
{
    public class ExternalMonitoringModel
    {
        public ExternalMonitoringModel()
        {
            UserId = new Guid();
            Username = "Anonymous";
        }

        public Guid UserId { get; set; }
        public string Username { get; set; }
    }
}