using System.IdentityModel.Tokens.Jwt;

namespace DailyNotes.Application.Common.Interfaces.Authentication
{
    public interface IJwtTokenDecoder
    {
        JwtSecurityToken Decode(string jwtToken);
    }
}