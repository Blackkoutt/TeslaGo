using Microsoft.EntityFrameworkCore;
using TeslaGoAPI.DB.Context;

namespace TeslaGoAPI.Extensions
{
    public static class BuilderDBExtenstions
    {
        public static void AddConnectionToDb(this WebApplicationBuilder builder, string connectionString)
        {
            builder.Services.AddDbContext<APIContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString(connectionString));
                options.ConfigureWarnings(warnings =>
                    warnings.Ignore(Microsoft.EntityFrameworkCore.Diagnostics.RelationalEventId.PendingModelChangesWarning));
            });
        }
    }
}
