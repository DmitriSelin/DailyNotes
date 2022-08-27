using DailyNotes.Application.Common.Interfaces.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Primitives;
using System.IdentityModel.Tokens.Jwt;

namespace DailyNotes.Infrastructure.Authentication
{
    public class JwtTokenDecoder : IJwtTokenDecoder
    {
        public Guid GetUserId(HttpContext context)
        {
            Guid userId = Guid.Empty;

            var requset = context.Request;

            if (requset != null)
            {
                requset.Headers.TryGetValue("Authorization", out StringValues bearer);

                if (bearer.Any())
                {
                    string token = bearer[0].Split(" ")[1];

                    var tokenHandler = new JwtSecurityTokenHandler();

                    var jwt = tokenHandler.ReadJwtToken(token);

                    userId = Guid.Parse(jwt.Claims.First(c => c.Type.Equals("sub")).Value);
                }
            }

            if (userId == Guid.Empty)
            {
                throw new Exception("Not correct Authorization header");
            }

            return userId;
        }
    }
}