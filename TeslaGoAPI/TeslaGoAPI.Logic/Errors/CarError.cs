using TeslaGoAPI.Logic.Response;
using TeslaGoAPI.Logic.Response.Abstract;

namespace TeslaGoAPI.Logic.Errors
{
    public sealed record CarError(HttpResponse? Details = null)
    {
        public static readonly Error NotFound = new(new NotFoundResponse("Cannot found Car for given CarId."));
    }
}
