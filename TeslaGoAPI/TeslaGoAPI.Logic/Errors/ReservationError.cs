using TeslaGoAPI.Logic.Response;
using TeslaGoAPI.Logic.Response.Abstract;

namespace TeslaGoAPI.Logic.Errors
{
    public sealed record ReservationError(HttpResponse? Details = null)
    {
        public static readonly Error NoAvailableCarsIsSelectedDateRange = new(new NotFoundResponse("No available cars of the given model for the selected date range."));
        public static readonly Error NoAvailableCarsInSelectedLocation = new(new NotFoundResponse("No available cars of the given model in selected location."));
    }
}
