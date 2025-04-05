﻿using System.Net;

namespace TeslaGoAPI.Logic.Response.Abstract
{
    public abstract class HttpResponse
    {
        protected HttpResponse(string message)
        {
            Details = new Dictionary<string, object>
            {
                { "errors", new[] { message } }
            };
        }
        protected HttpResponse(Dictionary<string, string> errors)
        {
            Details = new Dictionary<string, object>
            {
                { "errors", errors }
            };
        }
        public HttpStatusCode? Code { get; set; }
        public string? Title { get; set; }
        public string? Type { get; set; }
        public Dictionary<string, object> Details { get; set; }
    }
}
