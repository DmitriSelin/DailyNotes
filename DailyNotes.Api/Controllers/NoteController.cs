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
        public IActionResult CreateNewNote(CreateNoteRequest note)
        {
            var noteResult = _noteCreator.CreateNewNote(note.Name, note.Text);

            var noteResponse = new NoteResponse(
                noteResult.Note.Id, noteResult.Note.Name,
                noteResult.Note.CreationDate.ToString());

            return Ok(noteResponse);
        }
    }
}