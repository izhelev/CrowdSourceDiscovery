using System;
using System.Collections.Generic;
using System.Linq;
using CrowdSourceDiscovery.Contracts.Dtos.Dto;
using CrowdSourceDiscovery.Contracts.Dtos.Interfaces.Dao;
using CrowdSourceDiscovery.Domain;
using CrowdSourceDiscovery.Interfaces.Repository;

namespace CrowdSourceDiscovery.Repository
{
    public class Links : ILinks
    {
        private readonly ILinkDao _linkDao;

        public Links(ILinkDao linkDao)
        {
            _linkDao = linkDao;
        }

        public IList<Link> GetLinksByConnectionId(int connectionId)
        {
           var linkDtoList = _linkDao.GetByConnectionId(connectionId);
           return linkDtoList.Select(ToObject).ToList();
        }

        public void Save(int connectionId, IList<Link> links)
        {
            foreach (var link in links)
            {
                Save(connectionId, link);
            }
        }

        public void Save(int connectionId, Link link)
        {
            if (connectionId == 0)
                throw new ArgumentException("Connection id is null");

            if (link.Id == 0)
            {
                _linkDao.Insert(ToDto(link));
            }
            else
            {
                _linkDao.Update(ToDto(link));
            }
        }


        private static LinkDto ToDto(Link link)
        {
            return new LinkDto()
            {
                Id = link.Id,
                ConnectionId = link.ConnectionId,
                Url = link.Url.AbsoluteUri
            };
        }

        private static Link ToObject(LinkDto linkDto)
        {
            return new Link()
            {
                Id = linkDto.Id,
                ConnectionId = linkDto.ConnectionId,
                Url = new Uri(linkDto.Url)
            };
        }

        IList<Link> ILinks.GetLinksByConnectionId(int connectionId)
        {
            return GetLinksByConnectionId(connectionId);
        }
    }
}
