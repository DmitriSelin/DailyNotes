using Microsoft.AspNetCore.Mvc;

namespace DailyNotes.Api.Controllers
{
    [ApiExplorerSettings(IgnoreApi = true)]
    public class ExceptionsController : ControllerBase
    {
        [Route("/error")]
        public IActionResult Eror()
        {
            return Problem();
        }
    }
}