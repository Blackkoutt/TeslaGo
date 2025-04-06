using TeslaGoAPI.Logic.Identity.Services.Interfaces;
using TeslaGoAPI.Logic.Identity.Services.Services;
using TeslaGoAPI.Logic.UnitOfWork;

namespace TeslaGoAPI.Extensions
{
    public static class BuilderServicesExtensions
    {
        public static void AddUnitOfWork(this IServiceCollection services)
        {
            services.AddTransient<IUnitOfWork, UnitOfWork>();
        }
        public static void AddApplicationAuthServices(this IServiceCollection services)
        {
            services.AddScoped<IAuthService, AuthService>();
            services.AddSingleton<IJWTGeneratorService, JWTGeneratorService>();
        }
    }
}
