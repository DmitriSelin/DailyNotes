using DailyNotes.Domain.Entities;
using MediatR;

namespace DailyNotes.Application.Notes.Commands
{
    public record CreateNoteCommand(Guid UserId, string Name, string Text) : IRequest<Note>;
}