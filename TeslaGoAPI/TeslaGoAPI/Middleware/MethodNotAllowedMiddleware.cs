using System.Text.Json;
using TeslaGoAPI.Logic.Helpers;
using TeslaGoAPI.Logic.Response;

namespace TeslaGoAPI.Middleware
{
    public class MethodNotAllowedResponseMiddleware(RequestDelegate next)
    {
        private readonly RequestDelegate _next = next;

        public async Task InvokeAsync(HttpContext context)
        {
            await _next(context);

            if (context.Response.ContentType == null &&
                context.Response.StatusCode == StatusCodes.Status405MethodNotAllowed)
            {
                var httpMethod = context.Request.Method;

                context.Response.ContentType = ContentType.JSON;
                var customResponse = new MethodNotAllowedResponse($"The {httpMethod} method is not allowed for this resource.");

                var responseJson = JsonSerializer.Serialize(customResponse);
                await context.Response.WriteAsync(responseJson);
            }
        }
    }
}
