using DailyNotes.Application.Common.Interfaces.Authentication;
using DailyNotes.Application.Common.Interfaces.Services;
using DailyNotes.Infrastructure.Authentication;
using DailyNotes.Infrastructure.Services;
using Microsoft.Extensions.DependencyInjection;

namespace DailyNotes.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();
            services.AddSingleton<IDateTimeProvider, DateTimeProvider>();

            return services;
        }
    }
}