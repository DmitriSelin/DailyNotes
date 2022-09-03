namespace DailyNotes.Contracts.Note
{
    public class NoteResponse
    {
        public Guid NoteId { get; set; }

        public string Name { get; set; } = null!;

        public string Text { get; set; } = null!;

        public string CreationDate { get; set; } = null!;

        public NoteResponse() { } 

        public NoteResponse(Guid noteId, string name, string text, string creationDate)
        {
            NoteId = noteId;
            Name = name;
            Text = text;
            CreationDate = creationDate;
        }

        public override string ToString()
        {
            return $"Note: {Name} was written in {CreationDate}";
        }
    }
}