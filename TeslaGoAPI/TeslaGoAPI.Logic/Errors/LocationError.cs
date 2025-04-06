using TeslaGoAPI.Logic.Response;
using TeslaGoAPI.Logic.Response.Abstract;

namespace TeslaGoAPI.Logic.Errors
{
    public sealed record LocationError(HttpResponse? Details = null)
    {
        public static readonly Error PickupLocationNotFound = new(new NotFoundResponse("Cannot found Location for given PickupLocationId."));
        public static readonly Error ReturnLocationNotFound = new(new NotFoundResponse("Cannot found Location for given ReturnLocationId."));

    }
}
