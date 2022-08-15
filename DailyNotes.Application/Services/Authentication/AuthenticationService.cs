﻿using DailyNotes.Application.Common.Exceptions;
using DailyNotes.Application.Common.Interfaces.Authentication;
using DailyNotes.Application.Common.Persistence;
using DailyNotes.Domain.Entities;

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
            User? user = _userRepository.GetUserByEmail(email);

            if (user == null)
            {
                throw new UserException("User with the same email does not exists");
            }

            if (user.Password != password)
            {
                throw new UserException("Not correct password");
            }

            string? token = _jwtTokenGenerator.GenerateToken(user);

            return new AuthenticationResult(user, token);
        }

        public AuthenticationResult Register(string firstName, string lastName, string email, string password)
        {
            User? user = _userRepository.GetUserByEmail(email);

            if (user != null)
            {
                throw new UserException("User with the same email already exists");
            }

            var userId = Guid.NewGuid();

            user = new User(userId, firstName, lastName, email, password);

            _userRepository.AddUser(user);

            string? token = _jwtTokenGenerator.GenerateToken(user);

            return new AuthenticationResult(user, token);
        }
    }
}