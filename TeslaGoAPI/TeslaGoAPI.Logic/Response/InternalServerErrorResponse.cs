using System.Net;
using TeslaGoAPI.Logic.Response.Abstract;

namespace TeslaGoAPI.Logic.Response
{
    public class InternalServerErrorResponse : HttpResponse
    {

        public InternalServerErrorResponse(string message) : base(message)
        {
            Code = HttpStatusCode.InternalServerError;
            Title = "Internal Server Error";
            Type = "https://developer.mozilla.org/en-US/docs/Web/HTTP/Status/500";
        }
        public InternalServerErrorResponse(Dictionary<string, string> errors) : base(errors)
        {
            Code = HttpStatusCode.InternalServerError;
            Title = "Internal Server Error";
            Type = "https://developer.mozilla.org/en-US/docs/Web/HTTP/Status/500";
        }
    }
}
