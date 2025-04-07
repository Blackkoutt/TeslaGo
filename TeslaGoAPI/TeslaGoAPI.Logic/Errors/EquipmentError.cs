using TeslaGoAPI.Logic.Response;
using TeslaGoAPI.Logic.Response.Abstract;

namespace TeslaGoAPI.Logic.Errors
{
    public sealed record EquipmentError(HttpResponse? Details = null)
    {
        public static readonly Error NotFound = new(new NotFoundResponse("Cannot found  Equipment for given EquipmentId."));
    }
}
