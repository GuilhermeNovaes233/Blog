using System;

namespace BestBlogs.Domain.Entities
{
    public class Comment : Entity
    {
        public Comment(Guid postId, string content, string author)
        {
            PostId = postId;
            Content = content;
            Author = author;
        }

        public Guid PostId { get; private set; }
        public string Content { get; private set; }
        public string Author { get; private set; }
    }
}