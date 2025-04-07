using TeslaGoAPI.Logic.Response;
using TeslaGoAPI.Logic.Response.Abstract;

namespace TeslaGoAPI.Logic.Errors
{
    public sealed record BodyTypeError(HttpResponse? Details = null)
    {
        public static readonly Error NotFound = new(new NotFoundResponse("Cannot found BodyType for given BodyTypeId."));
    }
}
