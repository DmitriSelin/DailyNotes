using MediatR;
using DailyNotes.Contracts.Note;
using Microsoft.AspNetCore.Mvc;
using DailyNotes.Application.Notes.Commands;
using Microsoft.AspNetCore.Authorization;
using DailyNotes.Api.Extensions;

namespace DailyNotes.Api.Controllers
{
    [Route("notes")]
    [Authorize]
    [ApiController]
    public class NoteController : ControllerBase
    {
        private readonly ISender _sender;

        public NoteController(ISender sender)
        {
            _sender = sender;
        }
        
        [HttpPost("myWorks")]
        public async Task<IActionResult> CreateNewNote(CreateNoteRequest noteRequest)
        {
            var noteCommand = new CreateNoteCommand(Guid.NewGuid(), noteRequest.Name, noteRequest.Text);

            var userId = HttpContext.GetUserIdFromJwt();

            var note = await _sender.Send(noteCommand);

            var noteResponse = new NoteResponse(
                note.Id, note.Name,
                note.CreationDate.ToString());

            return Ok(noteResponse);
        }
    }
}