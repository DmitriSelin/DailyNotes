using DailyNotes.Domain.Entities;

namespace DailyNotes.Application.Services.Notes
{
    public class NoteResult
    {
        public Note Note { get; set; } = null!;

        public string Token { get; set; } = null!;

        public NoteResult(Note note, string token)
        {
            Note = note;
            Token = token;
        }
    }
}