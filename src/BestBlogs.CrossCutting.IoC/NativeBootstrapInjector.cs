using BestBlogs.Application.AppServices;
using BestBlogs.Application.Interfaces;
using BestBlogs.Infra.Context;
using BestBlogs.Infra.Interfaces;
using BestBlogs.Infra.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace BestBlogs.CrossCutting.IoC
{
    public static class NativeBootstrapInjector
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            services.AddDbContext<BlogContext>(options => options.UseInMemoryDatabase("InMemoryDb"));

            // Infra 
            services.AddScoped<ICommentRepository, CommentRepository>();
            services.AddScoped<IPostRepository, PostRepository>();

            //Application Services
            services.AddScoped<IPostAppService, PostAppService>();
            services.AddScoped<ICommentAppService, CommentAppService>();
        }
    }
}