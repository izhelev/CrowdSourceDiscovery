using System.Collections.Generic;
using System.Linq;
using CrowdSourceDiscovery.Contracts.Dtos.Dto;
using CrowdSourceDiscovery.Contracts.Dtos.Interfaces.Dao;
using CrowdSourceDiscovery.EntityFramework.DataLayer.EntityObjects;

namespace CrowdSourceDiscovery.EntityFramework.DataLayer.Repositories
{
    public class CommentRepository : RepositoryBase, ICommentdao
    {
        public int Insert(CommentDto dto)
        {
            var comment =  new Comment(dto.ConnectionId, dto.Text);
            Context.Comments.Add(comment);
            Context.SaveChanges();

            return comment.Id;
        }

        public void Update(CommentDto dto)
        {
            var comment = Context.Comments.First(c => c.Id == dto.Id);

            comment.Text = dto.Text;

            Context.SaveChanges();
        }

        public void Delete(CommentDto dto)
        {
            var comment = Context.Comments.First(c => c.Id == dto.Id);
            Context.Comments.Remove(comment);

            Context.SaveChanges();
        }

        public CommentDto Select(int id)
        {
            return ToDto(Context.Comments.First(c => c.Id == id));
        }

        public List<CommentDto> SelectByConnectionId(int connectionId)
        {
            var comments = Context.Comments.Where(c => c.ConnectionId == connectionId);
            return comments.Select(comment => ToDto(comment)).ToList();
        }

        private CommentDto ToDto(Comment comment)
        {
            return new CommentDto()
            {
               Id = comment.Id,
               ConnectionId = comment.ConnectionId,
               Text = comment.Text
            };
        }
    }
}
