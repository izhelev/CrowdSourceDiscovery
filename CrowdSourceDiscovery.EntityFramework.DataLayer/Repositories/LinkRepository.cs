using System.Collections.Generic;
using System.Linq;
using CrowdSourceDiscovery.Contracts.Dtos.Dto;
using CrowdSourceDiscovery.Contracts.Dtos.Interfaces.Dao;
using CrowdSourceDiscovery.EntityFramework.DataLayer.EntityObjects;

namespace CrowdSourceDiscovery.EntityFramework.DataLayer.Repositories
{
    public class LinkRepository: RepositoryBase, ILinkDao
    {
        public int Insert(LinkDto dto)
        {
            var newLink = new Link(dto.ConnectionId, dto.Url);
            Context.Links.Add(newLink);

            Context.SaveChanges();

            return newLink.Id;
        }

        public void Update(LinkDto dto)
        {
            throw new System.NotImplementedException();
        }

        public void Delete(LinkDto dto)
        {
            var toDelete = new Link(dto.ConnectionId, dto.Url);
            Context.Links.Remove(toDelete);

            Context.SaveChanges();          
        }

        public LinkDto Select(int id)
        {
            return ToDto(Context.Links.First(l => l.Id == id));
        }

        public IList<LinkDto> GetByConnectionId(int connectionId)
        {
            var links = Context.Links.Where(l => l.ConnectionId == connectionId);
            return links.Select(link => ToDto(link)).ToList();
        }

        private static LinkDto ToDto(Link link)
        {
            return new LinkDto()
            {
                Id = link.Id,
                ConnectionId = link.ConnectionId,
                Url = link.Url
            };
        }
    }
}
