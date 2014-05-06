using System.Collections.Generic;
using CrowdSourceDiscovery.Domain;

namespace CrowdSourceDiscovery.Interfaces.Repository
{
    public interface ILinks
    {
        IList<Link> GetLinksByConnectionId(int connectionId);
        void Save(int connectionId, IList<Link> links);
    }
}