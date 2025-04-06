using TeslaGoAPI.Middleware;

namespace TeslaGoAPI.Extensions
{
    public static class AppExtensionsMiddleware
    {
        public static void AddApplicationMiddleware(this WebApplication app)
        {
            app.UseMiddleware<UnauthorizedResponseMiddleware>();
            app.UseMiddleware<ForbiddenResponseMiddleware>();
            app.UseMiddleware<MethodNotAllowedResponseMiddleware>();
        }
    }
}
