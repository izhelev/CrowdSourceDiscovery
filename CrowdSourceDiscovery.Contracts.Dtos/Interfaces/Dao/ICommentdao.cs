using System.Collections.Generic;
using CrowdSourceDiscovery.Contracts.Dtos.Dto;

namespace CrowdSourceDiscovery.Contracts.Dtos.Interfaces.Dao
{
    public interface ICommentdao : IDAO<CommentDto>
    {
        List<CommentDto> SelectByConnectionId(int connectionId);
    }
}