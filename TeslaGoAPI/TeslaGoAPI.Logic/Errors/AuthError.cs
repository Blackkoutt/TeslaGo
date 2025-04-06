using TeslaGoAPI.Logic.Response;

namespace TeslaGoAPI.Logic.Errors
{
    public sealed record AuthError(Dictionary<string, string> Errors)
    {
        public static readonly Error HttpContextNotAvailable = new(new InternalServerErrorResponse("Unable to access the HTTP context."));
        public static readonly Error CanNotConfirmIdentity = new(new UnauthorizedResponse("Unable to confirm identity."));
        public static readonly Error UserHaventIdClaim = new(new BadRequestResponse("User does not have an ID in claims."));
        public static readonly Error EmailAlreadyTaken = new(new BadRequestResponse("Email address is already taken. Please use another one."));
        public readonly Error ErrorsWhileCreatingUser = new(new InternalServerErrorResponse(Errors));
        public static readonly Error InvalidEmailOrPassword = new(new UnauthorizedResponse("Invalid email or password."));
        public static readonly Error UserDoesNotHaveSpecificRole = new(new ForbiddenResponse("User does not have the required role to access this resource."));
        public static readonly Error UserDoesNotHavePremissionToResource = new(new ForbiddenResponse("User does not have permission to access this resource."));
    }
}
