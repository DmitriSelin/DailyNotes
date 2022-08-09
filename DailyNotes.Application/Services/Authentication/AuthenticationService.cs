using DailyNotes.Application.Common.Interfaces.Authentication;
using DailyNotes.Application.Common.Persistence;
using System;

namespace DailyNotes.Application.Services.Authentication
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IJwtTokenGenerator _jwtTokenGenerator;
        private readonly IUserRepository _userRepository;

        public AuthenticationService(IJwtTokenGenerator jwtTokenGenerator, IUserRepository userRepository)
        {
            _jwtTokenGenerator = jwtTokenGenerator;
            _userRepository = userRepository;
        }

        public AuthenticationResult Login(string email, string password)
        {
            var user = _userRepository.GetUserByEmail(email);

            if (user == null)
            {
                throw new Exception("User with the same email does not exists");
            }

            if (user.Password != password)
            {
                throw new Exception("Not correct password");
            }

            string? token = _jwtTokenGenerator.GenerateToken(user.Id, user.FirstName, user.LastName);

            return new AuthenticationResult(Guid.NewGuid(), user.FirstName, user.LastName, email, password, token);
        }

        public AuthenticationResult Register(string firstName, string lastName, string email, string password)
        {
            var user = _userRepository.GetUserByEmail(email);

            if (user != null)
            {
                throw new Exception("User with the same email alredy exists");
            }

            var userId = Guid.NewGuid();

            string? token = _jwtTokenGenerator.GenerateToken(userId, firstName, lastName);

            return new AuthenticationResult(userId, firstName, lastName, email, password, token);
        }
    }
}