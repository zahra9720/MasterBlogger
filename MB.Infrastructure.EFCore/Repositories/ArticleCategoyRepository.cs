using _01_Framework.Infrastructure;
using MB.Domain.ArticleCategoryAgg;
using System.Collections.Generic;
using System.Linq;

namespace MB.Infrastructure.EFCore.Repositories
{
    public class ArticleCategoyRepository : BaseRepository<long, ArticleCategory>, IArticleCategoryRepository
    {
        private readonly MasterBloggerContext _context;
        public ArticleCategoyRepository(MasterBloggerContext context)
            :base(context)
        {
            _context = context;
        }
    }
}
