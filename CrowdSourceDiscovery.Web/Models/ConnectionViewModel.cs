using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using CrowdSourceDiscovery.Domain;

namespace CrowdSourceDiscovery.Web.Models
{
    public class ConnectionViewModel
    {

        public int Id { get; set; }
        [Display(Name = "First article")]
        public string LinkOne { get; set; }
        [Display(Name = "Second article")]
        public string LinkTwo { get; set; }
        public bool IsViewerCreator { get; set; }
        public IList<ConnectionViewCommentModel> Comments { get; set; }
        public string LinkOneTitle { get; set; }
        public string LinkTwoTitle { get; set; }
    }

    public class ConnectionViewCommentModel
    {
        public string Username { get; set; }
        public string Text { get; set; }
    }
}