using DailyNotes.Application.Common.Exceptions;
using DailyNotes.Application.Common.Interfaces.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace DailyNotes.Application.Notes.Queries.GetListNote
{
    public class GetListNotesQueryHandler : IRequestHandler<GetListNoteQuery, List<NoteVm>>
    {
        private readonly IDailyNotesDbContext _dbContext;

        public GetListNotesQueryHandler(IDailyNotesDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<NoteVm>> Handle(GetListNoteQuery request, CancellationToken cancellationToken)
        {
            var notes = await
                _dbContext.Notes.Where(note => note.UserId == request.UserId).ToListAsync();

            if (notes.Count == 0)
            {
                throw new NoteException("This user has no notes", "You haven't created any notes yet",
                    (int)HttpStatusCode.NotFound);
            }

            var noteVmList = new List<NoteVm>();

            foreach (var note in notes)
            {
                noteVmList.Add(new NoteVm(note.Id, note.Name));
            }

            return noteVmList;
        }
    }
}