using System;
using System.Collections.Generic;
using System.Linq;
using CrowdSourceDiscovery.Contracts.Dtos.Dto;
using CrowdSourceDiscovery.Contracts.Dtos.Interfaces.Dao;
using CrowdSourceDiscovery.Domain;
using CrowdSourceDiscovery.Services.Interfaces;

namespace CrowdSourceDiscovery.Services
{
    public class Comments : IComments
    {
        private readonly ICommentdao _commentdao;

        public Comments(ICommentdao commentdao)
        {
            _commentdao = commentdao;
        }

        public void Save(int connectionId, IList<Comment> comments)
        {
            foreach (var comment in comments)
            {
                Save(connectionId, comment);
            }
        }

        public void Save(int connectionId, Comment comment)
        {
            if (connectionId == 0)
            {
                throw new ArgumentException("Connection id is null");
            }

            comment.ConnectionId = connectionId;

            if (comment.Id == 0)
            {
                _commentdao.Insert(ToDto(comment));
            }
            else
            {
                _commentdao.Update(ToDto(comment));   
            }
        }

        private static CommentDto ToDto(Comment comment)
        {
            return new CommentDto()
            {
                Id = comment.Id,
                ConnectionId = comment.ConnectionId,
                Text = comment.Text
            };
        }

        private static Comment ToEntity(CommentDto commentDto)
        {
            return new Comment()
            {
                Id = commentDto.Id,
                ConnectionId = commentDto.ConnectionId,
                Text = commentDto.Text
            };
        }

        public List<Comment> GetByConnection(int connectionId)
        {
            var commentDtos = _commentdao.SelectByConnectionId(connectionId);
            return commentDtos.Select(ToEntity).ToList();       
        }
    }
}