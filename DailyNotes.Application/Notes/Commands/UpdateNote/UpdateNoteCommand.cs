using MediatR;

namespace DailyNotes.Application.Notes.Commands.UpdateNote
{
    public record UpdateNoteCommand(Guid NoteId, Guid UserId, string Name, string Text) : IRequest;
}