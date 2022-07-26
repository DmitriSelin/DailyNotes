﻿namespace DailyNotes.Contracts.Authentication
{
    public class AuthenticationResponse
    {
        public Guid Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public string Token { get; set; }

        public AuthenticationResponse(Guid id, string firstName, string lastName, 
                                      string email, string password, string token)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Password = password;
            Token = token;
        }

        public override string ToString()
        {
            return $"{LastName} {FirstName} : {Email}; {Password}";
        }
    }
}