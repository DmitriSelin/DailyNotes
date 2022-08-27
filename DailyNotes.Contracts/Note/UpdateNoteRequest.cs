namespace DailyNotes.Contracts.Note
{
    public class UpdateNoteRequest
    {
        public Guid NoteId { get; set; }

        public string Name { get; set; } = null!;

        public string Text { get; set; } = null!;

        public UpdateNoteRequest() { }

        public UpdateNoteRequest(Guid noteId, string name, string text)
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