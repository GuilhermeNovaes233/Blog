using AutoMapper;
using BestBlogs.Application.Interfaces;
using BestBlogs.Application.ViewModels.Comments;
using BestBlogs.Application.ViewModels.Commons;
using BestBlogs.Domain.Entities;
using BestBlogs.Domain.Models;
using BestBlogs.Infra.Interfaces;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
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

        public async Task<Either<ErrorResponseViewModel, CommentViewModel>> GetByPostId(Guid postId)
        {
            try
            {
                var commentOnDb = await _commentRepository.GetByIdAsync(postId);
                if (commentOnDb == null)
                    return new Either<ErrorResponseViewModel, CommentViewModel>().NotFound(new ErrorResponseViewModel("Comment not found"));

                //TODO - CONFIGURAR O MAPPER
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
                var commentsOnDb = _commentRepository.GetAll();
                if (commentsOnDb == null)
                    return new Either<ErrorResponseViewModel, CommentResponseViewModel>().NotFound(new ErrorResponseViewModel("No comments found"));

                //TODO - CONFIGURAR O MAPEAMENTO
                var vm = _mapper.Map<CommentResponseViewModel>(commentsOnDb);

                return new Either<ErrorResponseViewModel, CommentResponseViewModel>().Ok(vm);
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
                //TODO - VERIFICAR SE JA EXISTE NO BANCO

                //TODO - CONFIGURAR O MAPEAMENTO
                var vm = _mapper.Map<Comment>(requestViewModel);

                await _commentRepository.AddAsync(vm);

                return new Either<ErrorResponseViewModel, SuccessResponseViewModel>().Ok(new SuccessResponseViewModel("Adicionado com sucesso"));
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
                var commentOnDb = await _commentRepository.GetByIdAsync(id);
                if (commentOnDb == null)
                    return new Either<ErrorResponseViewModel, SuccessResponseViewModel>().NotFound(new ErrorResponseViewModel("No comment removed"));

                await _commentRepository.RemoveAsync(commentOnDb);

                return new Either<ErrorResponseViewModel, SuccessResponseViewModel>().Ok(new SuccessResponseViewModel("Excluído com sucesso")); 
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
                var commentOnDb = await _commentRepository.GetByIdAsync(id);
                if (commentOnDb == null)
                    return new Either<ErrorResponseViewModel, SuccessResponseViewModel>().NotFound(new ErrorResponseViewModel("No comment not found"));

                //TODO - ATUALIZAR OS VALORES PELO PASSADO NA VIEW MODEL

                await _commentRepository.UpdateAsync(commentOnDb);

                return new Either<ErrorResponseViewModel, SuccessResponseViewModel>().Ok(new SuccessResponseViewModel("Atualizado com sucesso"));
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