using TeslaGoAPI.Logic.Response;
using TeslaGoAPI.Logic.Response.Abstract;

namespace TeslaGoAPI.Logic.Errors
{
    public sealed record AddressError(HttpResponse? Details = null)
    {
        public static readonly Error UserAlreadyHasAddress = new(new NotFoundResponse("User already has address."));
    }
}
