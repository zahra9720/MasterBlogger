using MB.Domain.ArticleCategoryAgg.Exceptions;
using System;

namespace MB.Domain.ArticleCategoryAgg.Services
{
    public class ArticleCategoryValidatorService : IArticleCategoryValidatorService
    {
        private readonly IArticleCategoryRepository _articleCategoryRepository;
        public ArticleCategoryValidatorService(IArticleCategoryRepository articleCategoryRepository)
        {
            _articleCategoryRepository = articleCategoryRepository;
        }
        public void CheckThatThisRecoredAlreadyExists(string title)
        {
            if (_articleCategoryRepository.Exists(x=>x.Title == title))
            {
                throw new DuplicatedRecoredException("This Record already exists in database");
            }
        }
    }
}
