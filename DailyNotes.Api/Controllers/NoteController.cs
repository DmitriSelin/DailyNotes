using DailyNotes.Application.Services.Notes;
using DailyNotes.Contracts.Note;
using Microsoft.AspNetCore.Mvc;

namespace DailyNotes.Api.Controllers
{
    [Route("notes")]
    [ApiController]
    public class NoteController : ControllerBase
    {
        private readonly INoteCreator _noteCreator;

        public NoteController(INoteCreator noteCreator)
        {
            _noteCreator = noteCreator;
        }

        
        [HttpPost("myWorks")]
        public IActionResult CreateNewNote([FromHeader] string jwtToken, CreateNoteRequest noteRequest)
        {
            var note = _noteCreator.CreateNewNote(noteRequest.Name, noteRequest.Text);                        

            var noteResponse = new NoteResponse(
                note.Id, note.Name,
                note.CreationDate.ToString());

            return Ok(noteResponse);
        }
    }
}