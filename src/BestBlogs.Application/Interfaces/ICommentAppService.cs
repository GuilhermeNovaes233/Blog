using BestBlogs.Application.ViewModels.Comments;
using BestBlogs.Application.ViewModels.Commons;
using BestBlogs.Domain.Models;

namespace BestBlogs.Application.Interfaces
{
    public interface ICommentAppService
    {
        Task<Either<ErrorResponseViewModel, CommentViewModel>> GetById(Guid id);
        Task<Either<ErrorResponseViewModel, CommentViewModel>> GetByPostId(Guid postId);
        Task<Either<ErrorResponseViewModel, CommentResponseViewModel>> GetAll(CommentRequestViewModel requestViewModel);
        Task<Either<ErrorResponseViewModel, SuccessResponseViewModel>> CreateComment(CommentRequestViewModel requestViewModel);
        Task<Either<ErrorResponseViewModel, SuccessResponseViewModel>> UpdateComment(Guid id, CommentRequestViewModel requestViewModel);
        Task<Either<ErrorResponseViewModel, SuccessResponseViewModel>> DeleteComment(Guid id);
    }
}