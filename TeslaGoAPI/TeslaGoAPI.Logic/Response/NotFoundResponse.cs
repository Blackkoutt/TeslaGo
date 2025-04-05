using System.Net;
using TeslaGoAPI.Logic.Response.Abstract;

namespace TeslaGoAPI.Logic.Response
{
    public class NotFoundResponse : HttpResponse
    {
        public NotFoundResponse(string message) : base(message)
        {
            Code = HttpStatusCode.NotFound;
            Title = "Not Found";
            Type = "https://developer.mozilla.org/en-US/docs/Web/HTTP/Status/404";
        }
    }
}
