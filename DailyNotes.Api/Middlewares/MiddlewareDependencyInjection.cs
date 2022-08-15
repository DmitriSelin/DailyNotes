namespace DailyNotes.Api.Middlewares
{
    public static class MiddlewareDependencyInjection
    {
        public static IApplicationBuilder AddCustomMiddleware(this IApplicationBuilder app)
        {
            app.UseMiddleware<ExceptionsHandlingMiddleware>();

            return app;
        }
    }
}