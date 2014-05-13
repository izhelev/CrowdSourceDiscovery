using System.Collections.Generic;
using System.Linq;
using CrowdSourceDiscovery.Contracts.Dtos.Dto;
using CrowdSourceDiscovery.Contracts.Dtos.Interfaces.Dao;
using CrowdSourceDiscovery.EntityFramework.DataLayer.EntityObjects;

namespace CrowdSourceDiscovery.EntityFramework.DataLayer.Repositories
{
    public class ConnectionRepository: RepositoryBase, IConnectiondao
    {
        public int Insert(ConnectionDto dto)
        {
            var connection = new Connection(dto.UserId);
            Context.Connections.Add(connection);
           
            Context.SaveChanges();

            return connection.Id;
        }

        public void Update(ConnectionDto dto)
        {
           /*Not required to be implemented yet*/
        }

        public void Delete(ConnectionDto dto)
        {
            var connection = Context.Connections.FirstOrDefault(c => c.Id == dto.Id);
            Context.Connections.Remove(connection);
            Context.SaveChanges();
        }

        public ConnectionDto Select(int id)
        {
            return ToDto(Context.Connections.First(c => c.Id == id));
        }

        public IEnumerable<ConnectionDto> GetAll()
        {
            var connections = Context.Connections.ToList();
            return connections.Select(ToDto);
        }
 

        private ConnectionDto ToDto(Connection connection)
        {
            return new ConnectionDto()
            {
                Id=connection.Id,
                UserId = connection.UserId
            };
        }
    }
}
