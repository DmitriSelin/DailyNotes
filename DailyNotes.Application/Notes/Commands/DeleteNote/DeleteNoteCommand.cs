using MediatR;

namespace DailyNotes.Application.Notes.Commands.DeleteNote
{
    public record DeleteNoteCommand(Guid NoteId, Guid UserId) : IRequest;
}