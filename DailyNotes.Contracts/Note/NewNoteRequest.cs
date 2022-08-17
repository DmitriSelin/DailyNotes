namespace DailyNotes.Contracts.Note
{
    public class NewNoteRequest
    {
        public string Name { get; set; } = null!;

        public string Text { get; set; } = null!;

        public DateTime CreationTime { get; set; }

        public string Token { get; set; } = null!;

        public NewNoteRequest() { }

        public NewNoteRequest(string name, string text, DateTime creationTime, string token)
        {
            Name = name;
            Text = text;
            CreationTime = creationTime;
            Token = token;
        }

        public override string ToString()
        {
            return $"Note: {Name} was written in {CreationTime}";
        }
    }
}