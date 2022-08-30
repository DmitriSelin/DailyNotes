namespace DailyNotes.Application.Services.Authentication
{
    public interface IAuthenticationService
    {
        public Task<AuthenticationResult> LoginAsync(string email, string password);

        public Task<AuthenticationResult> RegisterAsync(
            string firstName, string lastName, string email, string password);
    }
}