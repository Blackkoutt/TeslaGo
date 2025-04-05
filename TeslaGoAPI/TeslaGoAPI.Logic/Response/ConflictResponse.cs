using System.Net;
using TeslaGoAPI.Logic.Response.Abstract;

namespace TeslaGoAPI.Logic.Response
{
    public class ConflictResponse : HttpResponse
    {
        public ConflictResponse(string message) : base(message)
        {
            Code = HttpStatusCode.Conflict;
            Title = "Conflict";
            Type = "https://developer.mozilla.org/en-US/docs/Web/HTTP/Status/409";
        }
    }
}
