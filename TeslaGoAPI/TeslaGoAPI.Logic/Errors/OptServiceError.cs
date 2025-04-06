using Microsoft.AspNetCore.Http;
using TeslaGoAPI.Logic.Response;

namespace TeslaGoAPI.Logic.Errors
{
    public sealed record OptServiceError(HttpResponse? Details = null)
    {
        public static readonly Error NotFound = new(new NotFoundResponse("Cannot found OptService for given OptServiceId."));
    }
}
