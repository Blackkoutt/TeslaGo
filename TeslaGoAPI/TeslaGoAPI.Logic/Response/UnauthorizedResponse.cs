using System.Net;
using TeslaGoAPI.Logic.Response.Abstract;

namespace TeslaGoAPI.Logic.Response
{
    public class UnauthorizedResponse : HttpResponse
    {
        public UnauthorizedResponse(string message) : base(message)
        {
            Code = HttpStatusCode.Unauthorized;
            Title = "Unauthorized";
            Type = "https://developer.mozilla.org/en-US/docs/Web/HTTP/Status/401";
        }
    }
}
