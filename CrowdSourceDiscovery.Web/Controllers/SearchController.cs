using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using CrowdSourceDiscovery.Domain;
using CrowdSourceDiscovery.Services.Interfaces;
using CrowdSourceDiscovery.Web.Models;

namespace CrowdSourceDiscovery.Web.Controllers
{
    public class SearchController : Controller
    {
        private readonly IConnections _connections;

        public SearchController(IConnections connections)
        {
            _connections = connections;
        }

        public ActionResult Index(string query)
        {
            if (string.IsNullOrEmpty(query))
            {
                return View(new List<ConnectionListModel>());
            }
            var queryInvariant = query.ToLower();
            var connections = _connections.GetAll().Where(c => c.GetFirstLink().Title.ToLower().Contains(queryInvariant)
                || c.GetSecondLink().Title.ToLower().Contains(queryInvariant));

            var model = connections.Select(connection => new ConnectionListModel()
            {
                ConnectionId = connection.Id,
                LinkOneTitle = connection.GetFirstLink().Title,
                LinkTwoTitle = connection.GetSecondLink().Title,
                NumberOfComments = connection.Comments.Count
            }).OrderByDescending(m => m.NumberOfComments).ToList();

            return View(model);
        }
	}
}