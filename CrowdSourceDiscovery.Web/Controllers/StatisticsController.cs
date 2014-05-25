using System;
using System.Web.Mvc;
using CrowdSourceDiscovery.Web.Models;
using Microsoft.AspNet.Identity;

namespace CrowdSourceDiscovery.Web.Controllers
{
    public class StatisticsController : Controller
    {
       [ChildActionOnly]
        public ActionResult ExternalMonitoring()
       {
           if (!User.Identity.IsAuthenticated)
               return View(new ExternalMonitoringModel());

           var statisticsModel = new ExternalMonitoringModel()
           {
               UserId = new Guid(User.Identity.GetUserId()),
               Username = User.Identity.GetUserName()
           };

           return View(statisticsModel);
        }
	}
}