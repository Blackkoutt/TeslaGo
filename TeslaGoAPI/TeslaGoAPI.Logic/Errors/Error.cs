using TeslaGoAPI.Logic.Response;
using TeslaGoAPI.Logic.Response.Abstract;

namespace TeslaGoAPI.Logic.Errors
{
    public sealed record Error(HttpResponse? Details = null)
    {
        public static readonly Error None = new();
        public static readonly Error BadParameterType = new(new BadRequestResponse("Bad parameter type."));
        public static readonly Error NullObjectDetected = new(new BadRequestResponse("Null object was detected."));
        public static readonly Error NullParameter = new(new BadRequestResponse("Parameter in the request body is null."));
        public static readonly Error RouteParamOutOfRange = new(new BadRequestResponse("Parameter in the route is out of range."));
        public static readonly Error QueryParamOutOfRange = new(new BadRequestResponse("Query parameter is out of range."));
        public static readonly Error NotFound = new(new NotFoundResponse("Entity with the specified ID does not exist in the database."));
        public static readonly Error SuchEntityExistInDb = new(new ConflictResponse("Entity with the given name already exists in the database."));
        public static readonly Error ParsingError = new(new BadRequestResponse("Error while parsing value."));
        public static readonly Error ImageNotFound = new(new BadRequestResponse("Image not found."));
    }
}
