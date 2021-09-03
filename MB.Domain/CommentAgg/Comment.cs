﻿using _01_Framework.Domain;
using MB.Domain.ArticleAgg;
using System;

namespace MB.Domain.CommentAgg
{
    public class Comment : DomainBase<long>
    {
        public string Name { get; private set; }
        public string Email { get; private set; }
        public string Message { get; private set; }
        public int Status { get; private set; } //New = 0, Confirmed = 1, Cancled = 2
        public long ArticleId { get; private set; }
        public Article Article { get; private set; }
        protected Comment()
        {
        }
        public Comment(string name,string email,string message , long articleId)
        {
            Name = name;
            Email = email;
            Message = message;
            ArticleId = articleId;
            Status = Statuses.New;
        }
        public void Confirm()
        {
            Status = Statuses.Confirmed;
        }
        public void Cancel()
        {
            Status = Statuses.Canceled;
        }
    }
}
