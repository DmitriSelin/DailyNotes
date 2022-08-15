using DailyNotes.Domain.Entities;

namespace DailyNotes.Application.Common.Interfaces.Authentication
{
    public interface IJwtTokenGenerator
    {
        string GenerateToken(User user);
    }
}