﻿using System.Text.Json;
using TeslaGoAPI.Logic.Helpers;
using TeslaGoAPI.Logic.Response;

namespace TeslaGoAPI.Middleware
{
    public class UnauthorizedResponseMiddleware(RequestDelegate next)
    {
        private readonly RequestDelegate _next = next;

        public async Task InvokeAsync(HttpContext context)
        {
            await _next(context);
            if (context.Response.ContentType == null &&
                context.Response.StatusCode == StatusCodes.Status401Unauthorized)
            {
                context.Response.ContentType = ContentType.JSON;
                var customResponse = new UnauthorizedResponse("Please log in to access this resource.");

                var responseJson = JsonSerializer.Serialize(customResponse);
                await context.Response.WriteAsync(responseJson);
            }
        }
    }
}
