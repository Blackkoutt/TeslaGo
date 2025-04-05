using System.Net;
using TeslaGoAPI.Logic.Response.Abstract;

namespace TeslaGoAPI.Logic.Response
{
    public class ForbiddenResponse : HttpResponse
    {
        public ForbiddenResponse(string message) : base(message)
        {
            Code = HttpStatusCode.Forbidden;
            Title = "Forbidden";
            Type = "https://developer.mozilla.org/en-US/docs/Web/HTTP/Status/403";
        }
    }
}
