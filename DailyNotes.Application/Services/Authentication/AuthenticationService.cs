﻿using DailyNotes.Application.Common.Exceptions;
using DailyNotes.Application.Common.Interfaces.Authentication;
using DailyNotes.Application.Common.Persistence;
using DailyNotes.Domain.Entities;
using System.Net;

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

        public async Task<AuthenticationResult> LoginAsync(string email, string password)
        {
            return await Task.Run(() => Login(email, password));
        }

        private AuthenticationResult Login(string email, string password)
        {
            User? user = _userRepository.GetUserByEmailAsync(email).Result;

            if (user == null)
            {
                throw new UserException("User with the same email does not exists", "Invalid email", 
                    (int)HttpStatusCode.Unauthorized);
            }

            if (user.Password != password)
            {
                throw new UserException("Not correct password", "Invalid password", 
                    (int)HttpStatusCode.Unauthorized);
            }

            string? token = _jwtTokenGenerator.GenerateToken(user);

            return new AuthenticationResult(user, token);
        }

        public async Task<AuthenticationResult> RegisterAsync(
            string firstName, string lastName, string email, string password)
        {
            return await Task.Run(() => Register(firstName, lastName, email, password));
        }

        private AuthenticationResult Register(string firstName, string lastName, string email, string password)
        {
            User? user = _userRepository.GetUserByEmailAsync(email).Result;

            if (user != null)
            {
                throw new UserException(
                    "User with the same email already exists", "The user with this email is already registered", 
                    (int)HttpStatusCode.Conflict);
            }

            user = new User(Guid.NewGuid(), firstName, lastName, email, password);

            _userRepository.AddUserAsync(user);

            string? token = _jwtTokenGenerator.GenerateToken(user);

            return new AuthenticationResult(user, token);
        }
    }
}