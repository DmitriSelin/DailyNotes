using DailyNotes.Domain.Entities;

namespace DailyNotes.Application.Common.Interfaces.Persistence
{
    public interface INoteRepository
    {
        Task AddNoteAsync(Note note);
    }
}