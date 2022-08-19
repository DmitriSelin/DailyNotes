using DailyNotes.Domain.Entities;

namespace DailyNotes.Application.Services.Notes
{
    public interface INoteCreator
    {
        Note CreateNewNote(string name, string text, string token);
    }
}