using DailyNotes.Application.Common.Interfaces.Persistence;
using DailyNotes.Domain.Entities;
using MediatR;

namespace DailyNotes.Application.Notes.Queries.GetListNote
{
    public class GetListNotesQueryHandler : IRequestHandler<GetListNoteQuery, ListNotes>
    {
        private readonly IDailyNotesDbContext _dbContext;

        public GetListNotesQueryHandler(IDailyNotesDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<ListNotes> Handle(GetListNoteQuery request, CancellationToken cancellationToken)
        {
            var noteList = _dbContext.Notes.Where(user => user.UserId == request.UserId).ToList();

            if (noteList.Count == 0)
            {
                throw new Exception();
            }

            var noteNames = new List<string>();

            foreach(var note in noteList)
            {
                noteNames.Add(note.Name);
            }

            return new ListNotes(noteNames);
        }
    }
}
