using System;
using System.Web.Mvc;
using CrowdSourceDiscovery.Domain;
using CrowdSourceDiscovery.Services.Interfaces;
using CrowdSourceDiscovery.Web.Models;
using Microsoft.AspNet.Identity;

namespace CrowdSourceDiscovery.Web.Controllers
{
    [Authorize]
    public class CommentController : Controller
    {
        private readonly IConnections _connections;
        private readonly IComments _comments;

        public CommentController(IConnections connections, IComments comments)
        {
            _connections = connections;
            _comments = comments;
        }

        //
        // GET: /Comment/Create
        public ActionResult Create(int id)
        {
            var connection = _connections.GetConnection(id);

            var commentModel = new CommentFormModel()
            {
                ConnectionId = connection.Id
            };

            return View(commentModel);
        }

        //
        // POST: /Comment/Create
        [HttpPost]
        public ActionResult Create(CommentFormModel commentFormModel)
        {
            var connection = _connections.GetConnection(commentFormModel.ConnectionId);
            var comment = new Comment()
            {
                ConnectionId = connection.Id,
                Text = commentFormModel.Text,
                UserId = new Guid(User.Identity.GetUserId())
            };

            connection.AddComment(comment);
            _connections.Save(connection);

            return RedirectToAction("Details", "Connection",new {id=commentFormModel.ConnectionId});
        }

        //
        // GET: /Comment/Edit/5
        public ActionResult Edit(int id)
        {
            var comment = _comments.Get(id);
            var model = new CommentFormModel()
            {
                ConnectionId = comment.ConnectionId,
                Text = comment.Text
            };

            return View(model);
        }

        //
        // POST: /Comment/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, CommentFormModel model)
        {
            var comment = _comments.Get(id);
            comment.Text = model.Text;
            _comments.Save(model.ConnectionId, comment);

            return View();
        }

        //
        // GET: /Comment/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Comment/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
