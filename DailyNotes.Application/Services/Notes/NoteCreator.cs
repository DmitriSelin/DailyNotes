using DailyNotes.Application.Services.Notes;
using DailyNotes.Domain.Entities;

namespace DailyNotes.Infrastructure.Services
{
    public class NoteCreator : INoteCreator
    {
        public Note CreateNewNote(string name, string text, string token)
        {
            var noteId = Guid.NewGuid();

            return new Note(noteId, name, text);
        }
    }
}