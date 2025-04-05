using System.Net;
using TeslaGoAPI.Logic.Response.Abstract;

namespace TeslaGoAPI.Logic.Response
{
    public class BadRequestResponse : HttpResponse
    {
        public BadRequestResponse(string message) : base(message)
        {
            Code = HttpStatusCode.BadRequest;
            Title = "Bad Request";
            Type = "https://developer.mozilla.org/en-US/docs/Web/HTTP/Status/400";
        }
        public BadRequestResponse(Dictionary<string, string> errors) : base(errors)
        {
            Code = HttpStatusCode.BadRequest;
            Title = "Bad Request";
            Type = "https://developer.mozilla.org/en-US/docs/Web/HTTP/Status/400";
        }
    }
}
