using TeslaGoAPI.Settings;

namespace TeslaGoAPI.Extensions
{
    public static class BuilderAppConfigurationExtensions
    {
        public static void AddAppConfiguration(this WebApplicationBuilder builder)
        {
            builder.Services.Configure<ReservationSettings>(
                builder.Configuration.GetSection("ReservationSettings")
            );
        }
    }
}
