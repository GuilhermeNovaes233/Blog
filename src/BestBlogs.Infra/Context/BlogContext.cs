using BestBlogs.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace BestBlogs.Infra.Context
{
    public class BlogContext : DbContext
    {
        public BlogContext(DbContextOptions<BlogContext> options) : base(options)
        {
        }

        public DbSet<Comment> Comments { get; set; }

        public DbSet<Post> Posts { get; set; }
    }
}