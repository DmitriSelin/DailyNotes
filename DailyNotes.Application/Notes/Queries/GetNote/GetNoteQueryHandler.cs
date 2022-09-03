using DailyNotes.Application.Common.Interfaces.Persistence;
using DailyNotes.Application.Notes.Common;
using MediatR;
using Microsoft.EntityFrameworkCore;

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
                n => n.Id == request.NoteId && n.UserId == request.UserId);

            if (note == null)
            {
                throw new Exception("There are no notes with this id");
            }

            return new NoteResult(note);
        }
    }
}