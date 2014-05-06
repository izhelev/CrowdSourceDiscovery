using System.Collections.Generic;
using CrowdSourceDiscovery.Domain;

namespace CrowdSourceDiscovery.Interfaces.Repository
{
    public interface IComments
    {
        void Save(int connectionId, List<Comment> comments);
        void Save(int connectionId, Comment comment);
        List<Comment> GetByConnection(int connectionId);
    }
}