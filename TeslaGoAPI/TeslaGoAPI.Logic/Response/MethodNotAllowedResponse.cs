using System.Net;
using TeslaGoAPI.Logic.Response.Abstract;

namespace TeslaGoAPI.Logic.Response
{
    public class MethodNotAllowedResponse : HttpResponse
    {
        public MethodNotAllowedResponse(string message) : base(message)
        {
            Code = HttpStatusCode.MethodNotAllowed;
            Title = "Method Not Allowed";
            Type = "https://developer.mozilla.org/en-US/docs/Web/HTTP/Status/405";
        }
    }
}
