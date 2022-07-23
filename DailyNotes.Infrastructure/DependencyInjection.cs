using DailyNotes.Application.Common.Interfaces.Authentication;
using DailyNotes.Infrastructure.Authentication;
using Microsoft.Extensions.DependencyInjection;

namespace DailyNotes.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();

            return services;
        }
    }
}