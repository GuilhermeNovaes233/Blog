using System;

namespace BestBlogs.Application.ViewModels.Comments
{
    public class CommentViewModel
    {
        public Guid Id { get; set; }
        public Guid PostId { get; set; }
        public string Content { get; set; }
        public string Author { get; set; }
    }
}