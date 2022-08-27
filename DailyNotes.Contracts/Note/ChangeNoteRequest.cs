namespace DailyNotes.Contracts.Note
{
    public class ChangeNoteRequest
    {
        public Guid NoteId { get; set; }

        public string Name { get; set; } = null!;

        public string Text { get; set; } = null!;

        public ChangeNoteRequest() { }

        public ChangeNoteRequest(Guid noteId, string name, string text)
        {
            NoteId = noteId;
            Name = name;
            Text = text;
        }

        public override string ToString()
        {
            return $"Note: {Name}";
        }
    }
}