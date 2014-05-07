using System;
using System.Collections.Generic;
using CrowdSourceDiscovery.Domain;

namespace CrowdSourceDiscovery.Web.Models
{
    public class ConnectionViewModel
    {
        public Uri LinkOne { get; set; }
        public Uri LinkTwo { get; set; }
        public List<Comment> Comments { get; set; }

    }
}