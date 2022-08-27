using System.ComponentModel.DataAnnotations;

namespace DailyNotes.Domain.Entities
{
    public class Note
    {
        public Guid Id { get; set; }

        [StringLength(50, MinimumLength = 2)]
        public string Name { get; set; } = null!;

        [MinLength(1)]
        public string Text { get; set; } = null!;

        public DateTime CreationDate { get; set; }

        [MinLength(0)]
        public int LikesCount { get; set; }

        public Guid UserId { get; set; }

        public virtual User User { get; set; } = null!;

        public Note() { }

        public Note(Guid id, string name, string text)
        {
            Id = id;
            Name = name;
            Text = text;
            CreationDate = DateTime.UtcNow;
            LikesCount = 0;
        }

        public override string ToString()
        {
            return $"Note: {Name} was made in {CreationDate}";
        }
    }
}