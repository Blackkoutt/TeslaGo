using Coravel;
using TeslaGoAPI.Logic.Schedulers;

namespace TeslaGoAPI.Extensions
{
    public static class AppExtensionsScheduling
    {
        public static void UseSchediling(this WebApplication app)
        {
            app.Services.UseScheduler(scheduler => scheduler.Schedule<ReservationTask>().DailyAtHour(2));
        }
    }
}
