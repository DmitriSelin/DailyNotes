using MediatR;
using DailyNotes.Contracts.Note;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using DailyNotes.Application.Common.Interfaces.Authentication;
using DailyNotes.Application.Notes.Commands.CreateNote;
using DailyNotes.Application.Notes.Commands.UpdateNote;
using DailyNotes.Application.Notes.Commands.DeleteNote;
using DailyNotes.Application.Notes.Queries.GetListNote;

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

        [HttpGet("myWorks")]
        public async Task<IActionResult> GetNoteList()
        {
            Guid userId = _jwtTokenDecoder.GetUserId(HttpContext);

            var getListNoteQuery = new GetListNoteQuery(userId);

            var notes = await _sender.Send(getListNoteQuery);

            return Ok(notes);
        }

        [HttpGet("myWorks/select")]
        public async Task<IActionResult> GetSelectNote()
        {
            return null;
        }

        [HttpPost("myWorks")]
        public async Task<IActionResult> CreateNote(NoteRequest noteRequest)
        {
            Guid userId = _jwtTokenDecoder.GetUserId(HttpContext);

            var createNoteCommand = new CreateNoteCommand(userId, noteRequest.Name, noteRequest.Text);

            var noteResult = await _sender.Send(createNoteCommand);

            var noteResponse = new NoteResponse(
                noteResult.Note.Id, noteResult.Note.Name,
                noteResult.Note.CreationDate.ToString());

            return Ok(noteResponse);
        }

        [HttpPut("myWorks")]
        public async Task<IActionResult> EditNote(UpdateNoteRequest note)
        {
            Guid userId = _jwtTokenDecoder.GetUserId(HttpContext);

            var updateNoteCommand = new UpdateNoteCommand(note.NoteId, userId, note.Name, note.Text);

            await _sender.Send(updateNoteCommand);

            return Ok();
        }

        [HttpDelete("myWorks")]
        public async Task<IActionResult> DeleteNote([FromBody] Guid noteId)
        {
            Guid userId = _jwtTokenDecoder.GetUserId(HttpContext);

            var deleteNoteCommand = new DeleteNoteCommand(noteId, userId);

            await _sender.Send(deleteNoteCommand);

            return Ok();
        }
    }
}