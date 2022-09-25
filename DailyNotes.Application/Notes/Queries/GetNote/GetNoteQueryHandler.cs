using DailyNotes.Application.Common.Exceptions;
using DailyNotes.Application.Common.Interfaces.Persistence;
using DailyNotes.Application.Notes.Common;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace DailyNotes.Application.Notes.Queries.GetNote
{
    public class GetNoteQueryHandler : IRequestHandler<GetNoteQuery, NoteResult>
    {
        private readonly IDailyNotesDbContext _context;

        public GetNoteQueryHandler(IDailyNotesDbContext context)
        {
            _context = context;
        }

        public async Task<NoteResult> Handle(GetNoteQuery request, CancellationToken cancellationToken)
        {
            var note = await _context.Notes.FirstOrDefaultAsync(
                entity => entity.Id == request.NoteId && entity.UserId == request.UserId);

            if (note == null)
            {
                throw new NoteException("There are no notes with this id", "Can not give this note",
                    (int)HttpStatusCode.NotFound);
            }

            return new NoteResult(note);
        }
    }
}