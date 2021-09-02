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
            return _context.Articles.Include(x => x.ArticleCategory).Select(x => new ArticleQueryView
            {
                Id = x.Id,
                Title = x.Title,
                ShortDescription = x.ShortDescription,
                ArticleCategory = x.ArticleCategory.Title,
                Image = x.Image,
                Content=x.Content,
                CreationDate = x.CreationDate.ToString(CultureInfo.InvariantCulture)
            }).FirstOrDefault(x => x.Id == id);
        }

        public List<ArticleQueryView> GetArticles()
        {
            return _context.Articles.Include(x => x.ArticleCategory).Select(x => new ArticleQueryView
            {
                Id = x.Id,
                Title = x.Title,
                ShortDescription = x.ShortDescription,
                ArticleCategory = x.ArticleCategory.Title,
                Image=x.Image,
                CreationDate = x.CreationDate.ToString(CultureInfo.InvariantCulture)
            }).ToList();
        }
    }
}
