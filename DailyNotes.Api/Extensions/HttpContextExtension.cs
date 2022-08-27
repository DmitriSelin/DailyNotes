using Microsoft.Extensions.Primitives;
using System.IdentityModel.Tokens.Jwt;

namespace DailyNotes.Api.Extensions
{
    public static class HttpContextExtension
    {
        public static Guid? GetUserIdFromJwt(this HttpContext context)
        {
            Guid? userId = Guid.Empty;

            if (context != null)
            {
                var requset = context.Request;

                if (requset != null)
                {
                    requset.Headers.TryGetValue("Authorization", out StringValues bearer);

                    if (bearer.Any())
                    {
                        string token = bearer[0].Split(" ")[1];

                        var tokenHandler = new JwtSecurityTokenHandler();

                        var jwt = tokenHandler.ReadJwtToken(token);

                        userId = Guid.Parse(jwt.Claims.FirstOrDefault(c => c.Type.Equals("sub")).Value);
                    }
                }
            }

            return userId;
        }
    }
}
