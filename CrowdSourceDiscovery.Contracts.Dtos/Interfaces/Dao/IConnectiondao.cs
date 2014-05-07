using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using CrowdSourceDiscovery.Contracts.Dtos.Dto;

namespace CrowdSourceDiscovery.Contracts.Dtos.Interfaces.Dao
{
    public interface IConnectiondao : IDAO<ConnectionDto>
    {
        IEnumerable<ConnectionDto> GetAll();
    }
}