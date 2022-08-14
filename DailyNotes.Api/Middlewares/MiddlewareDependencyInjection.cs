namespace DailyNotes.Api.Middlewares
{
    public static class MiddlewareDependencyInjection
    {
        public static IApplicationBuilder AddCustomMiddlewares(this IApplicationBuilder buider)
        {
            buider.UseMiddleware<AuthenticationMiddleware>();

            return buider;
        }
    }
}