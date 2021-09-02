﻿using MB.Domain.ArticleCategoryAgg.Exceptions;

namespace MB.Domain.ArticleAgg.Services
{
    public class ArticleValidatorService : IArticleValidatorService
    {
        private readonly IArticleRepository _articleRepository;
        public ArticleValidatorService(IArticleRepository articleRepository)
        {
            _articleRepository = articleRepository;
        }
        public void CheckThatThisRecoredAlreadyExists(string title)
        {
            if (_articleRepository.Exists(title))
            {
                throw new DuplicatedRecoredException("This Record already exists in database");
            }
        }
    }
}
