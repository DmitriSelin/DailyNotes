using DailyNotes.Domain.Entities;

namespace DailyNotes.Application.Common.Persistence
{
    public interface IUserRepository
    {
        Task<User?> GetUserByEmailAsync(string email);

        Task<User?> GetUserByIdAsync(Guid userId);

        Task AddUserAsync(User user);
    }
}