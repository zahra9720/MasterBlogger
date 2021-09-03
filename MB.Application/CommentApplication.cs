using _01_Framework.Infrastructure;
using MB.Application.Contracts.Comment;
using MB.Domain.CommentAgg;
using System.Collections.Generic;

namespace MB.Application
{
    public class CommentApplication : ICommentApplication
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICommentRepository _commentRepository;
        public CommentApplication(ICommentRepository commentRepository, IUnitOfWork unitOfWork)
        {
            _commentRepository = commentRepository;
            _unitOfWork = unitOfWork;
        }

        public void Add(AddComment command)
        {
            _unitOfWork.BeginTran();
            var commnet = new Comment(command.Name, command.Email, command.Message, command.ArticleId);
            _commentRepository.Create(commnet);
            _unitOfWork.CommitTran();
        }

        public void Cancel(long id)
        {
            _unitOfWork.BeginTran();
            var commnet = _commentRepository.Get(id);
            commnet.Cancel();
            _unitOfWork.CommitTran();
        }

        public void Confirm(long id)
        {
            _unitOfWork.BeginTran();
            var comment = _commentRepository.Get(id);
            comment.Confirm();
            _unitOfWork.CommitTran();
        }

        public List<CommnetViewModel> GetList()
        {
            return _commentRepository.GetList();
        }
    }
}
