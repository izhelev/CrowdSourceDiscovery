using System.Collections.Generic;
using CrowdSourceDiscovery.Contracts.Dtos.Dto;

namespace CrowdSourceDiscovery.Contracts.Dtos.Interfaces.Dao
{
    public interface ILinkDao : IDAO<LinkDto>
    {
        IList<LinkDto> GetByConnectionId(int connectionId);
    }
}
