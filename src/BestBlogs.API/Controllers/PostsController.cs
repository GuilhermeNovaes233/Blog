using BestBlogs.Application.Interfaces;
using BestBlogs.Application.ViewModels.Comments;
using BestBlogs.Application.ViewModels.Commons;
using BestBlogs.Application.ViewModels.Posts;
using Microsoft.AspNetCore.Mvc;

namespace BestBlogs.API.Controllers
{
    [Route("api/[controller]")]
    public class PostsController : ControllerApi
    {
        private readonly IPostAppService _postAppService;

        public PostsController(IPostAppService postAppService)
        {
            _postAppService = postAppService;
        }

        [ProducesResponseType(typeof(PostViewModel), 200)]
        [ProducesResponseType(typeof(ErrorResponseViewModel), 404)]
        [ProducesResponseType(typeof(ErrorResponseViewModel), 500)]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
            => Return(await _postAppService.GetById(id));

        [ProducesResponseType(typeof(PostViewModel), 200)]
        [ProducesResponseType(typeof(ErrorResponseViewModel), 404)]
        [ProducesResponseType(typeof(ErrorResponseViewModel), 500)]
        [HttpGet()]
        public async Task<IActionResult> GetAll([FromRoute] PostRequestViewModel requestModel)
            => Return(await _postAppService.GetAll(requestModel));

        [ProducesResponseType(typeof(SuccessResponseViewModel), 200)]
        [ProducesResponseType(typeof(ErrorResponseViewModel), 404)]
        [ProducesResponseType(typeof(ErrorResponseViewModel), 500)]
        [HttpPost]
        public async Task<IActionResult> CreateComment([FromBody] PostRequestViewModel requestModel)
           => Return(await _postAppService.CreateComment(requestModel));

        [ProducesResponseType(typeof(SuccessResponseViewModel), 200)]
        [ProducesResponseType(typeof(ErrorResponseViewModel), 404)]
        [ProducesResponseType(typeof(ErrorResponseViewModel), 500)]
        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] PostRequestViewModel requestModel)
            => Return(await _postAppService.UpdateComment(id, requestModel));

        [ProducesResponseType(typeof(SuccessResponseViewModel), 200)]
        [ProducesResponseType(typeof(ErrorResponseViewModel), 404)]
        [ProducesResponseType(typeof(ErrorResponseViewModel), 500)]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
            => Return(await _postAppService.DeleteComment(id));
    }
}