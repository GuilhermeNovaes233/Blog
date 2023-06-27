using AutoMapper;
using BestBlogs.Application.Interfaces;
using BestBlogs.Application.ViewModels.Comments;
using BestBlogs.Application.ViewModels.Commons;
using BestBlogs.Domain.Models;
using BestBlogs.Infra.Interfaces;
using Microsoft.Extensions.Logging;
using System.Net;

namespace BestBlogs.Application.AppServices
{
    public class CommentAppService : ICommentAppService
    {
        private readonly ILogger<CommentAppService> _logger;
        public readonly ICommentRepository _commentRepository;
        private readonly IMapper _mapper;

        public CommentAppService(ILogger<CommentAppService> logger, ICommentRepository commentRepository, IMapper mapper)
        {
            _logger = logger;
            _commentRepository = commentRepository;
            _mapper = mapper;
        }

        public async Task<Either<ErrorResponseViewModel, CommentViewModel>> GetById(Guid id)
        {
            try
            {
                var commentOnDb = await _commentRepository.GetByIdAsync(id);
                if (commentOnDb == null)
                    return new Either<ErrorResponseViewModel, CommentViewModel>().NotFound(new ErrorResponseViewModel("Comment not found"));

                var vm = _mapper.Map<CommentViewModel>(commentOnDb);

                return new Either<ErrorResponseViewModel, CommentViewModel>().Ok(vm);
            }
            catch (Exception ex)
            {
                _logger.LogError($"ERROR: error to get a comment by id {ex.Message}");

                return new Either<ErrorResponseViewModel, CommentViewModel>()
                    .CustomError(new ErrorResponseViewModel(ex.Message), (int)HttpStatusCode.InternalServerError);
            }
        }

        public async Task<Either<ErrorResponseViewModel, CommentResponseViewModel>> GetAll(CommentRequestViewModel requestViewModel)
        {
            try
            {
                throw new NotImplementedException();
            }
            catch (Exception ex)
            {
                _logger.LogError($"ERROR: error to get all comments {ex.Message}");

                return new Either<ErrorResponseViewModel, CommentResponseViewModel>()
                    .CustomError(new ErrorResponseViewModel(ex.Message), (int)HttpStatusCode.InternalServerError);
            }
        }

        public async Task<Either<ErrorResponseViewModel, SuccessResponseViewModel>> CreateComment(CommentRequestViewModel requestViewModel)
        {
            try
            {
                throw new NotImplementedException();
            }
            catch (Exception ex)
            {
                _logger.LogError($"ERROR: error to create a comment {ex.Message}");

                return new Either<ErrorResponseViewModel, SuccessResponseViewModel>()
                    .CustomError(new ErrorResponseViewModel(ex.Message), (int)HttpStatusCode.InternalServerError);
            }
        }

        public async Task<Either<ErrorResponseViewModel, SuccessResponseViewModel>> DeleteComment(Guid id)
        {
            try
            {
                throw new NotImplementedException();
            }
            catch (Exception ex)
            {
                _logger.LogError($"ERROR: error to delete a comment {ex.Message}");

                return new Either<ErrorResponseViewModel, SuccessResponseViewModel>()
                    .CustomError(new ErrorResponseViewModel(ex.Message), (int)HttpStatusCode.InternalServerError);
            }
        }

        public async Task<Either<ErrorResponseViewModel, SuccessResponseViewModel>> UpdateComment(Guid id, CommentRequestViewModel requestViewModel)
        {
            try
            {
                throw new NotImplementedException();
            }
            catch (Exception ex)
            {
                _logger.LogError($"ERROR: error to update a comment {ex.Message}");

                return new Either<ErrorResponseViewModel, SuccessResponseViewModel>()
                    .CustomError(new ErrorResponseViewModel(ex.Message), (int)HttpStatusCode.InternalServerError);
            }
        }
    }
}