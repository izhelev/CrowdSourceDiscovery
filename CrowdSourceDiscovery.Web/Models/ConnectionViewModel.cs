using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using CrowdSourceDiscovery.Domain;

namespace CrowdSourceDiscovery.Web.Models
{
    public class ConnectionViewModel
    {

        public int Id { get; set; }
        [Display(Name = "Article one")]
        public string LinkOne { get; set; }
        [Display(Name = "Article two")]
        public string LinkTwo { get; set; }
        public bool IsViewerCreator { get; set; }
        public IList<ConnectionViewCommentModel> Comments { get; set; }
    }

    public class ConnectionViewCommentModel
    {
        public string Username { get; set; }
        public string Text { get; set; }
    }
}