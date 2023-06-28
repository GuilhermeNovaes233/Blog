using BestBlogs.Application.ViewModels.Commons;
using BestBlogs.Application.ViewModels.Posts;
using BestBlogs.Domain.Models;

namespace BestBlogs.Application.Interfaces
{
    public interface IPostAppService
    {
        Task<Either<ErrorResponseViewModel, PostViewModel>> GetById(Guid id);
        Task<Either<ErrorResponseViewModel, PostResponseViewModel>> GetAll(PostRequestViewModel requestViewModel);
        Task<Either<ErrorResponseViewModel, SuccessResponseViewModel>> CreatePost(PostRequestViewModel requestViewModel);
        Task<Either<ErrorResponseViewModel, SuccessResponseViewModel>> UpdatePost(Guid id, PostRequestViewModel requestViewModel);
        Task<Either<ErrorResponseViewModel, SuccessResponseViewModel>> DeletePost(Guid id);
    }
}