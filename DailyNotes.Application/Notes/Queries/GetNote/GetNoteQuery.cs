using DailyNotes.Application.Notes.Common;
using MediatR;

namespace DailyNotes.Application.Notes.Queries.GetNote
{
    public record GetNoteQuery(Guid NoteId, Guid UserId) : IRequest<NoteResult>;
}