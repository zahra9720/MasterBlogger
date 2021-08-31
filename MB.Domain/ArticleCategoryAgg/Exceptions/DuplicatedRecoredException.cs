using System;

namespace MB.Domain.ArticleCategoryAgg.Exceptions
{
    public class DuplicatedRecoredException : Exception
    {
        public DuplicatedRecoredException()
        {

        }
        public DuplicatedRecoredException(string message)
            :base(message)
        {

        }
    }
}
