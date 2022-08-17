using DailyNotes.Application.Services.Authentication;
using DailyNotes.Application.Services.Notes;
using DailyNotes.Infrastructure.Services;
using Microsoft.Extensions.DependencyInjection;

namespace DailyNotes.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddScoped<IAuthenticationService, AuthenticationService>();

            services.AddSingleton<INoteCreator, NoteCreator>();

            return services;
        }
    }
}