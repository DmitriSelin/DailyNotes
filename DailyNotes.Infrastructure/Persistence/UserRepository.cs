﻿using DailyNotes.Application.Common.Persistence;
using DailyNotes.Domain.Entities;
using DailyNotes.Infrastructure.Context;

namespace DailyNotes.Infrastructure.Persistence
{
    public class UserRepository : IUserRepository
    {
        private readonly DailyNotesDbContext _dbContext;

        public UserRepository(DailyNotesDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public User AddUser(User user)
        {
            _dbContext.Users.Add(user);

            _dbContext.SaveChanges();

            return user;
        }

        public User? GetUserByEmail(string email)
        {
            return _dbContext.Users.FirstOrDefault(x => x.Email == email);
        }
    }
}