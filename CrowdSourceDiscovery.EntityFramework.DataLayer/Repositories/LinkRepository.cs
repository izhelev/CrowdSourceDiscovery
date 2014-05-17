using System;
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
            var newLink = new Link(dto.ConnectionId, dto.Url, dto.Title);
            Context.Links.Add(newLink);

            Context.SaveChanges();

            return newLink.Id;
        }

        public void Update(LinkDto dto)
        {
            var link = Context.Links.First(c => c.Id == dto.Id);
            link.Url = dto.Url;
            link.Title = dto.Title;

            Context.SaveChanges();
        }

        public void Delete(LinkDto dto)
        {
            var toDelete = new Link(dto.ConnectionId, dto.Url, dto.Title);
            Context.Links.Remove(toDelete);

            Context.SaveChanges();          
        }

        public LinkDto Select(int id)
        {
            return ToDto(Context.Links.First(l => l.Id == id));
        }

        public IList<LinkDto> GetByConnectionId(int connectionId)
        {
            var links = Context.Links.Where(l => l.ConnectionId == connectionId).ToList();
            return links.Select(ToDto).ToList();
        }

        private static LinkDto ToDto(Link link)
        {
            return new LinkDto()
            {
                Id = link.Id,
                ConnectionId = link.ConnectionId,
                Url = link.Url,
                Title = link.Title
            };
        }

       
    }
}
