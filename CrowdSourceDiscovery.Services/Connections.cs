using System.Collections.Generic;
using System.Linq;
using CrowdSourceDiscovery.Contracts.Dtos.Dto;
using CrowdSourceDiscovery.Contracts.Dtos.Interfaces.Dao;
using CrowdSourceDiscovery.Domain;
using CrowdSourceDiscovery.Services.Interfaces;

namespace CrowdSourceDiscovery.Services
{
    public class Connections : IConnections
    {
        private readonly IConnectiondao _connectiondao;
        private readonly IComments _comments;
        private readonly ILinks _links;

        public Connections(IConnectiondao connectiondao, IComments comments, ILinks links)
        {
            _connectiondao = connectiondao;
            _comments = comments;
            _links = links;
        }

        public void Save(Connection connection)
        {
            if (connection.Id == 0)
            {
                int id = _connectiondao.Insert(ToDto(connection));
                connection.Id = id;
            }
            else
            {
                _connectiondao.Update(ToDto(connection));
            }

            _comments.Save(connection.Id, connection.Comments);
            _links.Save(connection.Id, connection.Links);
        }

        public Connection GetConnection(int id)
        {
            return ToEntity(_connectiondao.Select(id));
        }

        public IEnumerable<Connection> GetAll()
        {
           return _connectiondao.GetAll().Select(ToEntity);
        }

        private static ConnectionDto ToDto(Connection connection)
        {
            return new ConnectionDto()
            {
                Id = connection.Id,   
                UserId = connection.UserId
            };
        }

        private Connection ToEntity(ConnectionDto connectionDto)
        {
            return new Connection()
            {
                Id = connectionDto.Id,
                Links =  _links.GetLinksByConnectionId(connectionDto.Id),
                Comments = _comments.GetByConnection(connectionDto.Id),
                UserId = connectionDto.UserId
            };
        }
    }
}
