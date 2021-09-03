using MB.Domain.CommentAgg;
using MB.Infrastructure.EFCore;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace MB.Infrastructure.Query
{
    public class ArticleQuery : IArticleQuery
    {
        private readonly MasterBloggerContext _context;
        public ArticleQuery(MasterBloggerContext context)
        {
            _context = context;
        }

        public ArticleQueryView GetArticle(long id)
        {
            return _context.Articles
                .Include(x => x.ArticleCategory)
                .Select(x => new ArticleQueryView
            {
                Id = x.Id,
                Title = x.Title,
                ShortDescription = x.ShortDescription,
                ArticleCategory = x.ArticleCategory.Title,
                Image = x.Image,
                Content=x.Content,
                CreationDate = x.CreationDate.ToString(CultureInfo.InvariantCulture),
                CommentsCount = x.Comments.Count(z => z.Status == Statuses.Confirmed),
                Comments=MapComment(x.Comments.Where(z=>z.Status==Statuses.Confirmed))
                }).FirstOrDefault(x => x.Id == id);
        }
        private static List<CommentQueryView> MapComment(IEnumerable<Comment> comments)
        {
            var result = new List<CommentQueryView>();
            foreach (var comment in comments)
            {
                result.Add(new CommentQueryView
                {
                    Name = comment.Name,
                    CreationDate = comment.CreationDate.ToString(CultureInfo.InvariantCulture),
                    Message = comment.Message
                });
            }
            return result;
        }
        public List<ArticleQueryView> GetArticles()
        {
            return _context.Articles
                .Include(x => x.Comments)
                .Include(x => x.ArticleCategory)
                .Select(x => new ArticleQueryView
                {
                    Id = x.Id,
                    Title = x.Title,
                    ShortDescription = x.ShortDescription,
                    ArticleCategory = x.ArticleCategory.Title,
                    Image = x.Image,
                    CreationDate = x.CreationDate.ToString(CultureInfo.InvariantCulture),
                    CommentsCount = x.Comments.Count(z => z.Status == Statuses.Confirmed)
                }).ToList();
        }
    }
}
