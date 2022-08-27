using Microsoft.AspNetCore.Http;

namespace DailyNotes.Application.Common.Interfaces.Authentication
{
    public interface IJwtTokenDecoder
    {
        Guid GetUserId(HttpContext context);
    }
}