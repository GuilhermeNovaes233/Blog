using BestBlogs.Application.Interfaces;
using BestBlogs.Application.ViewModels.Comments;
using BestBlogs.Application.ViewModels.Commons;
using Microsoft.AspNetCore.Mvc;

namespace BestBlogs.API.Controllers
{
    [Route("api/[controller]")]
    public class CommentsController : ControllerApi
    {
        private readonly ICommentAppService _commentAppService;

        public CommentsController(ICommentAppService commentAppService)
        {
            _commentAppService = commentAppService;
        }

        [ProducesResponseType(typeof(CommentViewModel), 200)]
        [ProducesResponseType(typeof(ErrorResponseViewModel), 404)]
        [ProducesResponseType(typeof(ErrorResponseViewModel), 500)]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
            => Return(await _commentAppService.GetById(id));

        [ProducesResponseType(typeof(SuccessResponseViewModel), 200)]
        [ProducesResponseType(typeof(ErrorResponseViewModel), 404)]
        [ProducesResponseType(typeof(ErrorResponseViewModel), 500)]
        [HttpPost]
        public async Task<IActionResult> CreateComment([FromBody] CommentRequestViewModel requestModel)
           => Return(await _commentAppService.CreateComment(requestModel));

        [ProducesResponseType(typeof(SuccessResponseViewModel), 200)]
        [ProducesResponseType(typeof(ErrorResponseViewModel), 404)]
        [ProducesResponseType(typeof(ErrorResponseViewModel), 500)]
        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] CommentRequestViewModel requestModel)
            => Return(await _commentAppService.UpdateComment(id, requestModel));

        [ProducesResponseType(typeof(SuccessResponseViewModel), 200)]
        [ProducesResponseType(typeof(ErrorResponseViewModel), 404)]
        [ProducesResponseType(typeof(ErrorResponseViewModel), 500)]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
            => Return(await _commentAppService.DeleteComment(id));
    }
}