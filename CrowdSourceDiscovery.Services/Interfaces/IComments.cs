using System.Collections.Generic;
using CrowdSourceDiscovery.Domain;

namespace CrowdSourceDiscovery.Services.Interfaces
{
    public interface IComments
    {
        void Save(int connectionId, IList<Comment> comments);
        void Save(int connectionId, Comment comment);
        Comment Get(int id);
        List<Comment> GetByConnection(int connectionId);

    }
}