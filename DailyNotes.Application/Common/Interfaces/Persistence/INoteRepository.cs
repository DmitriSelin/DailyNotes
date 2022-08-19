using DailyNotes.Domain.Entities;

namespace DailyNotes.Application.Common.Interfaces.Persistence
{
    public interface INoteRepository
    {
        void AddNote(Note note);
    }
}