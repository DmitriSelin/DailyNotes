namespace DailyNotes.Domain.Entities
{
    public class Note
    {
        public Guid Id { get; set; }

        public string Name { get; set; } = null!;

        public string Text { get; set; } = null!;

        public DateTime CreationDate { get; set; }

        public int LikesCount { get; set; }

        public virtual User User { get; set; } = null!;

        public Note() { }

        public Note(Guid id, string name, string text, DateTime creationDate)
        {
            Id = id;
            Name = name;
            Text = text;
            CreationDate = creationDate;
            LikesCount = 0;
        }

        public override string ToString()
        {
            return $"Note: {Name} was made in {CreationDate}";
        }
    }
}