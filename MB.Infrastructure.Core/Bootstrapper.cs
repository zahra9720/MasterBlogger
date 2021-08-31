﻿using MB.Application;
using MB.Application.Contracts.ArticleCategory;
using MB.Domain.ArticleCategoryAgg;
using MB.Infrastructure.EFCore;
using MB.Infrastructure.EFCore.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace MB.Infrastructure.Core
{
    public class Bootstrapper
    {
        public static void Config(IServiceCollection services , string connectionString)
        {
            services.AddTransient<IArticleCategoryApplication, ArticleCategoryApplication>();
            services.AddTransient<IArticleCategoryRepository, ArticleCategoyRepository>();
            services.AddDbContext<MasterBloggerContext>(options => options.UseSqlServer(connectionString));
        }
    }
}
