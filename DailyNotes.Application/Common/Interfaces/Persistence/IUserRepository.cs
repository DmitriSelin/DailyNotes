using DailyNotes.Domain.Entities;

namespace DailyNotes.Application.Common.Persistence
{
    public interface IUserRepository
    {
        User? GetUserByEmail(string email);

        void AddUser(User user);
    }
}