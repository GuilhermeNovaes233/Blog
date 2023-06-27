using System;

namespace BestBlogs.Domain.Entities
{
    public class Post : Entity
    {
        public Post(string title, string content)
        {
            Title = title;
            Content = content;
        }

        public string Title { get; set; }
        public string Content { get; set; }
    }
}