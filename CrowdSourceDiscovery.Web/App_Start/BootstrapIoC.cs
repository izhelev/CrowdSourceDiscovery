using System.Net.Http;
using System.Reflection;
using System.Security.Principal;
using System.Web;
using System.Web.Mvc;
using CrowdSourceDiscovery.Contracts.Dtos;
using CrowdSourceDiscovery.Contracts.Dtos.Interfaces.Dao;
using CrowdSourceDiscovery.EntityFramework.DataLayer;
using CrowdSourceDiscovery.EntityFramework.DataLayer.Repositories;
using CrowdSourceDiscovery.Services;
using CrowdSourceDiscovery.Services.Interfaces;
using CrowdSourceDiscovery.Web.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using SimpleInjector;
using SimpleInjector.Integration.Web.Mvc;

namespace CrowdSourceDiscovery.Web.App_Start
{
    public class BootstrapIoC
    {
        public static void RegisterContainer()
        {
            // Create the container as usual.
            var container = new Container();

            //Helpers
            container.RegisterPerWebRequest<IPrincipal>(() => 
                HttpContext.Current.User ?? new GenericPrincipal(new GenericIdentity(string.Empty), null));

            // Register your types, for instance:
            container.Register<IConnections, Connections>();
            container.Register<IComments, Comments>();
            container.Register<ILinks, Links>();

            /*Register DAO*/
            container.Register<IConnectiondao,ConnectionRepository>();
            container.Register<ICommentdao, CommentRepository>();
            container.Register<ILinkDao, LinkRepository>();

            // This is an extension method from the integration package.
            container.RegisterMvcControllers(Assembly.GetExecutingAssembly());

            // This is an extension method from the integration package as well.
            container.RegisterMvcIntegratedFilterProvider();

            container.Register<IUserStore<ApplicationUser>>(() => new UserStore<ApplicationUser>(new CSDiscoveryContext()));

            container.Verify();

            DependencyResolver.SetResolver(
                new SimpleInjectorDependencyResolver(container));
        }
    }
}