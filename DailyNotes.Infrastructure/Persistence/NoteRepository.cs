using DailyNotes.Application.Common.Interfaces.Persistence;
using DailyNotes.Domain.Entities;
using DailyNotes.Infrastructure.Context;

namespace DailyNotes.Infrastructure.Persistence
{
    public class NoteRepository : INoteRepository
    {
        private readonly DailyNotesDbContext _dbContext;

        public NoteRepository(DailyNotesDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void AddNote(Note note)
        {
            _dbContext.Add(note);

            _dbContext.SaveChanges();
        }
    }
}