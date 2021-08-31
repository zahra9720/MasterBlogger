﻿using MB.Domain.ArticleCategoryAgg;
using System.Collections.Generic;
using System.Linq;

namespace MB.Infrastructure.EFCore.Repositories
{
    public class ArticleCategoyRepository : IArticleCategoryRepository
    {
        private readonly MasterBloggerContext _context;
        public ArticleCategoyRepository(MasterBloggerContext context)
        {
            _context = context;
        }
        public void Add(ArticleCategory entity)
        {
            _context.ArticleCategories.Add(entity);
            Save();
        }

        public bool Exists(string title)
        {
            return _context.ArticleCategories.Any(x => x.Title == title);
        }

        public ArticleCategory Get(long id)
        {
            return _context.ArticleCategories.FirstOrDefault(x => x.Id == id);
        }

        public List<ArticleCategory> GetAll()
        {
            return _context.ArticleCategories.OrderByDescending(x => x.Id).ToList();
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
