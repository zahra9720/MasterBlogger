using System.Collections.Generic;

namespace MB.Application.Contracts.Comment
{
    public interface ICommentApplication
    {
        List<CommnetViewModel> GetList();
        void Add(AddComment command);
    }
}
