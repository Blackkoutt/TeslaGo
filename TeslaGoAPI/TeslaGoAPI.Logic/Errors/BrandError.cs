using TeslaGoAPI.Logic.Response;
using TeslaGoAPI.Logic.Response.Abstract;

namespace TeslaGoAPI.Logic.Errors
{
    public sealed record BrandError(HttpResponse? Details = null)
    {
        public static readonly Error NotFound = new(new NotFoundResponse("Cannot found Brand for given BrandId."));
    }
}
