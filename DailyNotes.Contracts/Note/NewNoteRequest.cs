namespace DailyNotes.Contracts.Note
{
    public class NewNoteRequest
    {
        public Guid UserId { get; set; }

        public string Name { get; set; } = null!;

        public string Text { get; set; } = null!;

        public DateTime CreationTime { get; set; }

        public NewNoteRequest() { }

        public NewNoteRequest(Guid userId, string name, string text, DateTime creationTime)
        {
            UserId = userId;
            Name = name;
            Text = text;
            CreationTime = creationTime;
        }

        public override string ToString()
        {
            return $"Note: {Name} was written in {CreationTime}";
        }
    }
}