using System.Reflection;
using System.Web.Mvc;
using CrowdSourceDiscovery.Contracts.Dtos.Interfaces.Dao;
using CrowdSourceDiscovery.EntityFramework.DataLayer.Repositories;
using CrowdSourceDiscovery.Interfaces.Repository;
using CrowdSourceDiscovery.Repository;
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

            container.Verify();

            DependencyResolver.SetResolver(
                new SimpleInjectorDependencyResolver(container));
        }
    }
}