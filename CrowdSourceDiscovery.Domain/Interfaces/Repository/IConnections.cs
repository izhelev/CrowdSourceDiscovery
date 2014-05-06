using CrowdSourceDiscovery.Domain;

namespace CrowdSourceDiscovery.Interfaces.Repository
{
    public interface IConnections
    {
        void Save(Connection connection);
        Connection GetConnection(int id);
    }
}