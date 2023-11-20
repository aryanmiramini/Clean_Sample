using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace Clean_Api.Controllers
{
    public class ErrorController : ControllerBase
    {
        
        [Route("/error")]
        [HttpGet]
        public IActionResult Error()
        {
            Exception? exception = HttpContext.Features.Get<IExceptionHandlerFeature>()?.Error;
            var (statusCode, message) = exception switch
            {
                _ => (StatusCodes.Status500InternalServerError,"An unexpected error occurred")
            };
            return Problem(statusCode:statusCode , title:message);
        }
    }
}
