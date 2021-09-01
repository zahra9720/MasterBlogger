using MB.Domain.ArticleAgg;
using MB.Domain.ArticleCategoryAgg.Services;
using System;
using System.Collections.Generic;

namespace MB.Domain.ArticleCategoryAgg
{
    public class ArticleCategory
    {
        public long Id { get; private set; }
        public string Title { get; private set; }
        public bool IsDeleted { get; private set; }
        public DateTime CreationDate { get; private set; }
        public ICollection<Article> Articles { get; private set; }
        protected ArticleCategory()
        {
        }
        public ArticleCategory(string title , IArticleCategoryValidatorService validatorService)
        {
            GuardAgainstEmptyTitle(title);
            validatorService.CheckThatThisRecoredAlreadyExists(title);
            Title = title;
            IsDeleted = false;
            CreationDate = DateTime.Now;
            Articles = new List<Article>();
        }
        public void GuardAgainstEmptyTitle(string title)
        {
            if (string.IsNullOrWhiteSpace(title))
            {
                throw new ArgumentException();
            }
        }
        public void Rename(string title)
        {
            GuardAgainstEmptyTitle(title);
            Title = title;
        }
        public void Remove()
        {
            IsDeleted = true;
        }
        public void Activate()
        {
            IsDeleted = false;
        }
    }
}
