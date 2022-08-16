namespace DailyNotes.Domain.Entities
{
    public class User
    {
        public Guid Id { get; set; }

        public string FirstName { get; set; } = null!;

        public string LastName { get; set; } = null!;

        public string Email { get; set; } = null!;

        public string Password { get; set; } = null!;

        public virtual ICollection<Note> Notes { get; set; } = null!;

        public User() { }

        public User(Guid id, string firstName, string lastName, string email, string password)
        {
            Id = Id;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Password = password;
        }

        public override string ToString()
        {
            return $"{LastName} {FirstName} : {Email}";
        }
    }
}