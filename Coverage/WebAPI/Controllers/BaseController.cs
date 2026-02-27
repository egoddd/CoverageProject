using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Coverage.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public abstract class BaseController : ControllerBase
    {
        protected readonly ILogger<BaseController> _logger;

        public BaseController(ILogger<BaseController> logger)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        /// <summary>
        /// Handles API responses consistently with success data.
        /// </summary>
        protected IActionResult SuccessResponse<T>(T data, string message = "Request successful")
        {
            return Ok(new
            {
                success = true,
                message,
                data
            });
        }

        /// <summary>
        /// Handles API responses consistently with error messages.
        /// </summary>
        protected IActionResult ErrorResponse(string message, int statusCode = 400)
        {
            _logger.LogError(message);
            return StatusCode(statusCode, new
            {
                success = false,
                message
            });
        }

        /// <summary>
        /// Handles unexpected exceptions and logs the details.
        /// </summary>
        protected IActionResult HandleException(Exception ex)
        {
            _logger.LogError(ex, ex.Message);
            return StatusCode(500, new
            {
                success = false,
                message = "An unexpected error occurred. Please try again later."
            });
        }
    }
}
