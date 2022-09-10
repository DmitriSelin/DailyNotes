using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace DailyNotes.Api.Controllers
{
    [ApiExplorerSettings(IgnoreApi = true)]
    public class ExceptionsController : ControllerBase
    {
        [Route("/error")]
        public IActionResult Error() 
        {
            Exception? exception = HttpContext.Features.Get<IExceptionHandlerFeature>()?.Error;

            return Problem();
        }
    }
}