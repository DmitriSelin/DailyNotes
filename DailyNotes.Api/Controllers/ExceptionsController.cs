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
            return Problem();
        }
    }
}