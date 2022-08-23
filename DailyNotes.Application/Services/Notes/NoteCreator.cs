using DailyNotes.Application.Common.Exceptions;
using DailyNotes.Application.Common.Interfaces.Authentication;
using DailyNotes.Application.Common.Interfaces.Persistence;
using DailyNotes.Application.Common.Persistence;
using DailyNotes.Application.Services.Notes;
using DailyNotes.Domain.Entities;

namespace DailyNotes.Infrastructure.Services
{
    public class NoteCreator : INoteCreator
    {
        private readonly INoteRepository _noteRepository;

        public NoteCreator(INoteRepository noteRepository)
        {
            _noteRepository = noteRepository;
        }

        public Note CreateNewNote(string name, string text)
        {
            var noteId = Guid.NewGuid();

            var note = new Note(noteId, name, text);

            _noteRepository.AddNoteAsync(note);

            return note;
        }
    }
}