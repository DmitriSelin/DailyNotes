using DailyNotes.Application.Common.Persistence;
using DailyNotes.Domain.Entities;
using DailyNotes.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace DailyNotes.Infrastructure.Persistence
{
    public class UserRepository : IUserRepository
    {
        private readonly DailyNotesDbContext _dbContext;

        public UserRepository(DailyNotesDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddUserAsync(User user)
        {
            await _dbContext.Users.AddAsync(user);

            await _dbContext.SaveChangesAsync();
        }

        public async Task<User?> GetUserByIdAsync(Guid userId)
        {
            return await _dbContext.Users.FirstOrDefaultAsync(user => user.Id == userId);
        }

        public async Task<User?> GetUserByEmailAsync(string email)
        {
            return await _dbContext.Users.FirstOrDefaultAsync(user => user.Email == email);
        }
    }
}