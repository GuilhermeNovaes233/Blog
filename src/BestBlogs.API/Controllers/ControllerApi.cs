using BestBlogs.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace BestBlogs.API.Controllers
{
    [ApiController]
    public abstract class ControllerApi : ControllerBase
    {
        [ApiExplorerSettings(IgnoreApi = true)]
        protected IActionResult Return<TError, TSuccess>(Either<TError, TSuccess> result)
        {
            if (result.IsFailure)
            {
                return StatusCode(result.StatusCode, result.Error);
            }

            if (result.Value != null)
            {
                return StatusCode(result.StatusCode, result.Value);
            }

            return NoContent();
        }
    }
}