using MB.Application.Contracts.Comment;
using MB.Domain.CommentAgg;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace MB.Infrastructure.EFCore.Repositories
{
    public class CommentRepository : ICommentRepository
    {
        private readonly MasterBloggerContext _context;
        public CommentRepository(MasterBloggerContext context)
        {
            _context = context;
        }

        public void CreateAndSave(Comment entity)
        {
            _context.Comments.Add(entity);
            _context.SaveChanges();
        }

        public List<CommnetViewModel> GetList()
        {
            return _context.Comments.Include(x => x.Article)
                .Select(x => new CommnetViewModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    Email = x.Email,
                    Message = x.Message,
                    CreationDate = x.CreationDate.ToString(CultureInfo.InvariantCulture),
                    Status = x.Status,
                    Article = x.Article.Title
                }).ToList();
        }
    }
}
