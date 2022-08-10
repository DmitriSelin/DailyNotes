using DailyNotes.Application.Common.Persistence;
using DailyNotes.Domain.Entities;

namespace DailyNotes.Infrastructure.Persistence
{
    public class UserRepository : IUserRepository
    {
        public User AddUser(User user)
        {
            return user;
        }

        public User? GetUserByEmail(string email)
        {
            return new User();
        }
    }
}