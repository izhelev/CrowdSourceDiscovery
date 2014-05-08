using System.Collections.Generic;
using CrowdSourceDiscovery.Domain;

namespace CrowdSourceDiscovery.Services.Interfaces
{
    public interface ILinks
    {
        IList<Link> GetLinksByConnectionId(int connectionId);
        void Save(int connectionId, IList<Link> links);
    }
}