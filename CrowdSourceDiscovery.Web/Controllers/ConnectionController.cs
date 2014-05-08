using System.Linq;
using System.Web.Mvc;
using CrowdSourceDiscovery.Domain;
using CrowdSourceDiscovery.Domain.Domain;
using CrowdSourceDiscovery.Web.Models;
using CrowdSourceDiscovery.Services.Interfaces;

namespace CrowdSourceDiscovery.Web.Controllers
{
    public class ConnectionController : Controller
    {
        private readonly IConnections _connections;

        public ConnectionController(IConnections connections)
        {
            _connections = connections;
        }

        public ActionResult Index()
        {
            var connections = _connections.GetAll();
            var models = connections.Select(connection => new ConnectionListModel()
            {
                ConnectionId = connection.Id,
                LinkOne = connection.GetFirstLink().Url.AbsoluteUri,
                LinkTwo = connection.GetSecondLink().Url.AbsoluteUri,
                NumberOfComments = connection.Comments.Count
            }).ToList();

            return View(models);
        }


        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(ConnectionFormModel connectionModel)
        {
            var connection = new Connection();
            connection.AddComment(new Comment(connectionModel.Comment));
            connection.AddLinks(new Link(connectionModel.LinkOne));
            connection.AddLinks(new Link(connectionModel.LinkTwo));
            _connections.Save(connection);

            return View();
        }

        public ActionResult Edit(int id)
        {
            var connection = _connections.GetConnection(id);
            var connectionFormModel = new ConnectionFormModel()
            {
                ConnectionId = connection.Id,
                LinkOne = connection.GetFirstLink().Url.AbsoluteUri,
                LinkTwo = connection.GetSecondLink().Url.AbsoluteUri,
                Comment = connection.GetOriginalComment().Text           
            };

            return View(connectionFormModel);
        }

        [HttpPost]
        public ActionResult Edit(ConnectionFormModel model)
        {
           var connection = _connections.GetConnection(model.ConnectionId);
           connection.SaveOriginalComment(model.Comment);
           connection.UpdateFirstLink(new Link(model.LinkOne)); 
           connection.UpdateSecondLink(new Link(model.LinkTwo)); 
         
           _connections.Save(connection);

            return View();
        }

        public ActionResult Details(int id)
        {
            var connection = _connections.GetConnection(id);
            if (connection == null)
            {
                return HttpNotFound();
            }

            var connectionModel = new ConnectionViewModel()
            {
                 Id = connection.Id,
                 LinkOne = connection.GetFirstLink().Url.AbsoluteUri,
                 LinkTwo = connection.GetSecondLink().Url.AbsoluteUri,
                 Comments = connection.Comments                 
            };

            return View(connectionModel);
        }
    }
}