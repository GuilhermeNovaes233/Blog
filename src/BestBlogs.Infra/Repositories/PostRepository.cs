using BestBlogs.Domain.Entities;
using BestBlogs.Infra.Context;
using BestBlogs.Infra.Interfaces;

namespace BestBlogs.Infra.Repositories
{
    public class PostRepository : RepositoryBase<Post>, IPostRepository
    {
        public PostRepository(BlogContext context) : base(context) { }
    }
}