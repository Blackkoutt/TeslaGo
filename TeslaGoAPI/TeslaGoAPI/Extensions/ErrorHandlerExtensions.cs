using Microsoft.AspNetCore.Mvc;
using System.Net;
using TeslaGoAPI.Logic.Errors;
using TeslaGoAPI.Logic.Result;

namespace TeslaGoAPI.Extensions
{
    public static class ErrorHandlerExtensions
    {
        public static IActionResult Handle(this Error error, ControllerBase controller)
        {
            return error.Details!.Code switch
            {
                HttpStatusCode.BadRequest => controller.BadRequest(error.Details),
                HttpStatusCode.Unauthorized => controller.Unauthorized(error.Details),
                HttpStatusCode.Conflict => controller.Conflict(error.Details),
                HttpStatusCode.MethodNotAllowed => controller.StatusCode((int)HttpStatusCode.MethodNotAllowed, error.Details),
                HttpStatusCode.NotFound => controller.NotFound(error.Details),
                HttpStatusCode.Forbidden => controller.StatusCode((int)HttpStatusCode.Forbidden, error.Details),
                _ => controller.StatusCode((int)HttpStatusCode.InternalServerError, error.Details)
            };
        }

    }
}
