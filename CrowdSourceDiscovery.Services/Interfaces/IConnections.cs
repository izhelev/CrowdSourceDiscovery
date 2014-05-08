using System.Collections.Generic;
using CrowdSourceDiscovery.Domain.Domain;

namespace CrowdSourceDiscovery.Services.Interfaces
{
    public interface IConnections
    {
        void Save(Connection connection);
        Connection GetConnection(int id);
        IEnumerable<Connection> GetAll();
    }
}