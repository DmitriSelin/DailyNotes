using DailyNotes.Application.Common.Interfaces.Authentication;
using System.IdentityModel.Tokens.Jwt;

namespace DailyNotes.Infrastructure.Authentication
{
    public class JwtTokenDecoder : IJwtTokenDecoder
    {
        public JwtSecurityToken Decode(string jwtToken)
        {
            return new JwtSecurityTokenHandler().ReadJwtToken(jwtToken);
        }
    }
}