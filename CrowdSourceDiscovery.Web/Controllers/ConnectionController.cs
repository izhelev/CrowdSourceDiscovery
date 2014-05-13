using System;
using System.Linq;
using System.Web.Mvc;
using CrowdSourceDiscovery.Contracts.Dtos;
using CrowdSourceDiscovery.Domain;
using CrowdSourceDiscovery.Web.Helper;
using CrowdSourceDiscovery.Web.Models;
using CrowdSourceDiscovery.Services.Interfaces;
using Microsoft.AspNet.Identity;

namespace CrowdSourceDiscovery.Web.Controllers
{
    [Authorize]
    public class ConnectionController : Controller
    {
        private readonly IConnections _connections;
        private readonly UserManager<ApplicationUser> _manager;
        private readonly PermissionHelper _permissionHelper;

        public ConnectionController(IConnections connections, UserManager<ApplicationUser> manager, PermissionHelper permissionHelper)
        {
            _connections = connections;
            _manager = manager;
            _permissionHelper = permissionHelper;
        }

        [AllowAnonymous]
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
            var currentUserId = new Guid(User.Identity.GetUserId());
            var connection = new Connection {UserId = currentUserId};
            connection.AddComment(new Comment(connectionModel.Comment, currentUserId));
            connection.AddLinks(new Link(connectionModel.LinkOne));
            connection.AddLinks(new Link(connectionModel.LinkTwo));
            _connections.Save(connection);

            return RedirectToAction("Details", new { id=connection.Id});
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

           return RedirectToAction("Details", new { id = connection.Id });
        }

        [AllowAnonymous]
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
                 IsViewerCreator = _permissionHelper.CheckCurrentViewerIsUser(connection.UserId)
 
            };

            var commentModels = connection.Comments.Select(comment => new ConnectionViewCommentModel()
            {
                Username = _manager.FindById(comment.UserId.ToString()).UserName,
                Text = comment.Text
            }).ToList();

            connectionModel.Comments = commentModels;

            return View(connectionModel);
        }
    }
}