using System;

namespace BestBlogs.Application.ViewModels.Posts
{
    public class PostRequestViewModel
    {
        public Guid Id { get; set; }
        public string Content { get; set; }
        public string Author { get; set; }
    }
}