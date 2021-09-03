using MB.Application.Contracts.Comment;
using System.Collections.Generic;

namespace MB.Domain.CommentAgg
{
    public interface ICommentRepository
    {
        List<CommnetViewModel> GetList();
        void CreateAndSave(Comment entity);
    }
}
