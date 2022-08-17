using DailyNotes.Application.Services.Notes;
using DailyNotes.Domain.Entities;

namespace DailyNotes.Infrastructure.Services
{
    public class NoteCreator : INoteCreator
    {
        public void CreateNewNote(string name, string text, DateTime creationTime)
        {
            var noteId = Guid.NewGuid();

            var note = new Note(noteId, name, text);

            return new NoteResult(note, "token");
        }
    }
}