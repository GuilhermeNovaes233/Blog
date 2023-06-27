using BestBlogs.Domain.Entities;
using BestBlogs.Infra.Context;
using BestBlogs.Infra.Interfaces;

namespace BestBlogs.Infra.Repositories
{
    public class CommentRepository : RepositoryBase<Comment>, ICommentRepository
    {
        public CommentRepository(BlogContext context) : base(context) { }
    }
}