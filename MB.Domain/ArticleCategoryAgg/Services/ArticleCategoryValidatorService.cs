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
            if (_articleCategoryRepository.Exists(title))
            {
                throw new DuplicateWaitObjectException("This Record already exists in database");
            }
        }
    }
}
