using MediatR;
using DailyNotes.Contracts.Note;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using DailyNotes.Application.Common.Interfaces.Authentication;
using DailyNotes.Application.Notes.Commands.CreateNote;

namespace DailyNotes.Api.Controllers
{
    [Route("notes")]
    [Authorize]
    [ApiController]
    public class NoteController : ControllerBase
    {
        private readonly ISender _sender;
        private readonly IJwtTokenDecoder _jwtTokenDecoder; 

        public NoteController(ISender sender, IJwtTokenDecoder jwtTokenDecoder)
        {
            _sender = sender;
            _jwtTokenDecoder = jwtTokenDecoder;
        }
        
        [HttpPost("myWorks")]
        public async Task<IActionResult> CreateNewNote(CreateNoteRequest noteRequest)
        {
            Guid userId = _jwtTokenDecoder.GetUserId(HttpContext);

            var noteCommand = new CreateNoteCommand(userId, noteRequest.Name, noteRequest.Text);

            var noteResult = await _sender.Send(noteCommand);

            var noteResponse = new NoteResponse(
                noteResult.Note.Id, noteResult.Note.Name,
                noteResult.Note.CreationDate.ToString());

            return Ok(noteResponse);
        }
    }
}