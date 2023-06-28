using AutoMapper;
using BestBlogs.Application.Interfaces;
using BestBlogs.Application.ViewModels.Posts;
using BestBlogs.Application.ViewModels.Commons;
using BestBlogs.Domain.Models;
using BestBlogs.Infra.Interfaces;
using Microsoft.Extensions.Logging;
using System.Net;

namespace BestBlogs.Application.AppServices
{
    public class PostAppService : IPostAppService
    {
        private readonly ILogger<PostAppService> _logger;
        public readonly IPostRepository _postRepository;
        private readonly IMapper _mapper;

        public PostAppService(ILogger<PostAppService> logger, IPostRepository postRepository, IMapper mapper)
        {
            _logger = logger;
            _postRepository = postRepository;
            _mapper = mapper;
        }

        public async Task<Either<ErrorResponseViewModel, PostViewModel>> GetById(Guid id)
        {
            try
            {
                var postOnDb = await _postRepository.GetByIdAsync(id);
                if (postOnDb == null)
                    return new Either<ErrorResponseViewModel, PostViewModel>().NotFound(new ErrorResponseViewModel("Post not found"));

                var vm = _mapper.Map<PostViewModel>(postOnDb);

                return new Either<ErrorResponseViewModel, PostViewModel>().Ok(vm);
            }
            catch (Exception ex)
            {
                _logger.LogError($"ERROR: error to get a post by id {ex.Message}");

                return new Either<ErrorResponseViewModel, PostViewModel>()
                    .CustomError(new ErrorResponseViewModel(ex.Message), (int)HttpStatusCode.InternalServerError);
            }
        }

        public async Task<Either<ErrorResponseViewModel, PostResponseViewModel>> GetAll(PostRequestViewModel requestViewModel)
        {
            try
            {
                var postOnDb = _postRepository.GetAll();
                if (postOnDb == null)
                    return new Either<ErrorResponseViewModel, PostViewModel>().NotFound(new ErrorResponseViewModel("No posts found"));

                var vm = _mapper.Map<PostViewModel>(postOnDb);

                return new Either<ErrorResponseViewModel, PostViewModel>().Ok(vm);
            }
            catch (Exception ex)
            {
                _logger.LogError($"ERROR: error to get all posts {ex.Message}");

                return new Either<ErrorResponseViewModel, PostResponseViewModel>()
                    .CustomError(new ErrorResponseViewModel(ex.Message), (int)HttpStatusCode.InternalServerError);
            }
        }

        public async Task<Either<ErrorResponseViewModel, SuccessResponseViewModel>> CreatePost(PostRequestViewModel requestViewModel)
        {
            try
            {
                var postOnDb = await _postRepository.AddAsync();
                if (postOnDb == null)
                    return new Either<ErrorResponseViewModel, PostViewModel>().NotFound(new ErrorResponseViewModel("No post created"));

                var vm = _mapper.Map<PostViewModel>(postOnDb);

                return new Either<ErrorResponseViewModel, PostViewModel>().Ok(vm);
            }
            catch (Exception ex)
            {
                _logger.LogError($"ERROR: error to create a post {ex.Message}");

                return new Either<ErrorResponseViewModel, SuccessResponseViewModel>()
                    .CustomError(new ErrorResponseViewModel(ex.Message), (int)HttpStatusCode.InternalServerError);
            }
        }

        public async Task<Either<ErrorResponseViewModel, SuccessResponseViewModel>> DeletePost(Guid id)
        {
            try
            {
                var postOnDb = await _postRepository.RemoveAsync(id);
                if (postOnDb == null)
                    return new Either<ErrorResponseViewModel, PostViewModel>().NotFound(new ErrorResponseViewModel("No post removed"));

                var vm = _mapper.Map<PostViewModel>(postOnDb);

                return new Either<ErrorResponseViewModel, PostViewModel>().Ok(vm);
            }
            catch (Exception ex)
            {
                _logger.LogError($"ERROR: error to delete a post {ex.Message}");

                return new Either<ErrorResponseViewModel, SuccessResponseViewModel>()
                    .CustomError(new ErrorResponseViewModel(ex.Message), (int)HttpStatusCode.InternalServerError);
            }
        }

        public async Task<Either<ErrorResponseViewModel, SuccessResponseViewModel>> UpdatePost(Guid id, PostRequestViewModel requestViewModel)
        {
            try
            {
                var postOnDb = await _postRepository.UpdateAsync(id);
                if (postOnDb == null)
                    return new Either<ErrorResponseViewModel, PostViewModel>().NotFound(new ErrorResponseViewModel("No post updated"));

                var vm = _mapper.Map<PostViewModel>(postOnDb);

                return new Either<ErrorResponseViewModel, PostViewModel>().Ok(vm);
            }
            catch (Exception ex)
            {
                _logger.LogError($"ERROR: error to update a post {ex.Message}");

                return new Either<ErrorResponseViewModel, SuccessResponseViewModel>()
                    .CustomError(new ErrorResponseViewModel(ex.Message), (int)HttpStatusCode.InternalServerError);
            }
        }
    }
}