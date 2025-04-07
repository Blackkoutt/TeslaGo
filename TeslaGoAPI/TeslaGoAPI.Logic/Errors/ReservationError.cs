using TeslaGoAPI.Logic.Response;
using TeslaGoAPI.Logic.Response.Abstract;

namespace TeslaGoAPI.Logic.Errors
{
    public sealed record ReservationError(HttpResponse? Details = null)
    {
        public static readonly Error NotFound = new(new NotFoundResponse("Cannot found Reservation for given ReservationId."));
        public static readonly Error NoAvailableCarsIsSelectedDateRange = new(new NotFoundResponse("No available cars of the given model for the selected date range."));
        public static readonly Error NoAvailableCarsInSelectedLocation = new(new NotFoundResponse("No available cars of the given model in selected location."));
        public static readonly Error IsExpired = new(new NotFoundResponse("Cannot perform action because Reservation is expired."));
        public static readonly Error ReservationStartsSoon = new(new NotFoundResponse("Cannot perform action because Reservation starts in next 6 hours."));
        public static readonly Error NoAvailableConcreteCarInSelectedLocation = new(new NotFoundResponse("This car is not available in selected location."));

    }
}
