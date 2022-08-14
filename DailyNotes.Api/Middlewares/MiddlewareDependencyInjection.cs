namespace DailyNotes.Api.Middlewares
{
    public static class MiddlewareDependencyInjection
    {
        public static IApplicationBuilder AddCustomMiddlewares(this IApplicationBuilder builder)
        {
            builder.UseMiddleware<AuthenticationMiddleware>();

            return builder;
        }
    }
}