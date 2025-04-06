using TeslaGoAPI.Logic.Response;
using TeslaGoAPI.Logic.Response.Abstract;

namespace TeslaGoAPI.Logic.Errors
{
    public sealed record UserError(HttpResponse? Details = null)
    {
        public static readonly Error UserNotFound = new(new NotFoundResponse("User with the provided ID does not exist in the database."));
        public static readonly Error UserEmailNotFound = new(new NotFoundResponse("Unable to find the user's email address in the database."));
    }

}
