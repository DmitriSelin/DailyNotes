using DailyNotes.Application.Common.Interfaces.Authentication;
using DailyNotes.Application.Common.Interfaces.Persistence;
using DailyNotes.Application.Common.Interfaces.Services;
using DailyNotes.Application.Common.Persistence;
using DailyNotes.Infrastructure.Authentication;
using DailyNotes.Infrastructure.Context;
using DailyNotes.Infrastructure.Persistence;
using DailyNotes.Infrastructure.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DailyNotes.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services,
            ConfigurationManager configuration)
        {
            services.Configure<JwtSettings>(configuration.GetSection(JwtSettings.SectionName));

            services.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();
            services.AddSingleton<IDateTimeProvider, DateTimeProvider>();

            services.AddDbContext<DailyNotesDbContext>();

            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<INoteRepository, NoteRepository>();

            return services;
        }
    }
}