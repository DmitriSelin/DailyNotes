using MediatR;

namespace DailyNotes.Application.Notes.Queries.GetListNote
{
    public record GetListNoteQuery(Guid UserId) : IRequest<ListNotes>;
}
