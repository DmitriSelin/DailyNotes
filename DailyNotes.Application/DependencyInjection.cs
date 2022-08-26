using DailyNotes.Application.Services.Authentication;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace DailyNotes.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddScoped<IAuthenticationService, AuthenticationService>();

            services.AddMediatR(Assembly.GetExecutingAssembly());

            return services;
        }
    }
}