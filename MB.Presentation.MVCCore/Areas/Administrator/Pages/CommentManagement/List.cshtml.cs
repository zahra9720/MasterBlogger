using MB.Application.Contracts.Comment;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;

namespace MB.Presentation.MVCCore.Areas.Administrator.Pages.CommentManagement
{
    public class ListModel : PageModel
    {
        public List<CommnetViewModel> Commnets { get; set; }
        private readonly ICommentApplication _commentApplication;
        public ListModel(ICommentApplication commentApplication)
        {
            _commentApplication = commentApplication;
        }
        public void OnGet()
        {
            Commnets = _commentApplication.GetList();
        }
    }
}
