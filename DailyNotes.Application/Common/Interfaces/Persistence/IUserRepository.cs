using DailyNotes.Domain.Entities;

namespace DailyNotes.Application.Common.Persistence
{
    public interface IUserRepository
    {
        User? GetUserByEmail(string email);

        User? GetUserById(Guid userId);

        void AddUser(User user);
    }
}