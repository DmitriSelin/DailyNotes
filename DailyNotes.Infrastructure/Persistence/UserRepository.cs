using DailyNotes.Application.Common.Persistence;
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

        public async Task AddUserAsync(User user)
        {
            await _dbContext.Users.AddAsync(user);

            await _dbContext.SaveChangesAsync();
        }

        public async Task<User?> GetUserByIdAsync(Guid userId)
        {
            return await Task.Run(() => GetUserById(userId));
        }

        private User? GetUserById(Guid userId)
        {
            return _dbContext.Users.FirstOrDefault(user => user.Id == userId);
        }

        public async Task<User?> GetUserByEmailAsync(string email)
        {
            return await Task.Run(() => GetUserByEmail(email));
        }

        private User? GetUserByEmail(string email)
        {
            return _dbContext.Users.FirstOrDefault(x => x.Email == email);
        }
    }
}