namespace DailyNotes.Contracts.Note
{
    public class NoteRequest
    {
        public string Name { get; set; } = null!;

        public string Text { get; set; } = null!;

        public NoteRequest() { }

        public NoteRequest(string name, string text)
        {
            Name = name;
            Text = text;
        }

        public override string ToString()
        {
            return $"Note: {Name}";
        }
    }
}