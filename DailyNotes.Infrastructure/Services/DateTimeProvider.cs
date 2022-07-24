using DailyNotes.Application.Common.Interfaces.Services;

namespace DailyNotes.Infrastructure.Services
{
    public class DateTimeProvider : IDateTimeProvider
    {
        public DateTime UtcNow => DateTime.UtcNow;
    }
}