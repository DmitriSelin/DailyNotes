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

        public async Task AddNoteAsync(Note note)
        {
            await _dbContext.AddAsync(note);

            await _dbContext.SaveChangesAsync();
        }
    }
}