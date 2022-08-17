using DailyNotes.Contracts.Note;
using Microsoft.AspNetCore.Mvc;

namespace DailyNotes.Api.Controllers
{
    [Route("notes")]
    [ApiController]
    public class NoteController : ControllerBase
    {
        [HttpPost("myWorks")]
        public IActionResult CreateNewNote(NewNoteRequest note)
        {


            return Ok();
        }
    }
}
