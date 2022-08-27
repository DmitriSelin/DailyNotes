using DailyNotes.Domain.Entities;
using MediatR;

namespace DailyNotes.Application.Notes.Commands.CreateNote
{
    public record CreateNoteCommand(Guid UserId, string Name, string Text) : IRequest<CreateNoteResult>;
}