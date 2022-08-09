using DailyNotes.Domain.Entities;

namespace DailyNotes.Application.Services.Authentication
{
    public class AuthenticationResult
    {
        public User User { get; set; }

        public string Token { get; set; }

        public AuthenticationResult(User user, string token)
        {
            User = user;
            Token = token;
        }

        public override string ToString()
        {
            return $"{User.LastName} {User.FirstName} : {User.Email}; {User.Password}";
        }
    }
}