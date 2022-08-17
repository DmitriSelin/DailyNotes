namespace DailyNotes.Api.Middlewares
{
    public static class MiddlewareDependencyInjection
    {
        public static IApplicationBuilder AddCustomMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ExceptionsHandlingMiddleware>();
        }
    }
}