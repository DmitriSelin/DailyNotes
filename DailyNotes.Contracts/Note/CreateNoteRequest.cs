namespace DailyNotes.Contracts.Note
{
    public class CreateNoteRequest
    {
        public string Name { get; set; } = null!;

        public string Text { get; set; } = null!;

        public string Token { get; set; } = null!;

        public CreateNoteRequest() { }

        public CreateNoteRequest(string name, string text, string token)
        {
            Name = name;
            Text = text;
            Token = token;
        }

        public override string ToString()
        {
            return $"Note: {Name}";
        }
    }
}