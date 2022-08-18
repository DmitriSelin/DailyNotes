namespace DailyNotes.Contracts.Note
{
    public class CreateNoteRequest
    {
        public string Name { get; set; } = null!;

        public string Text { get; set; } = null!;

        public CreateNoteRequest() { }

        public CreateNoteRequest(string name, string text)
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