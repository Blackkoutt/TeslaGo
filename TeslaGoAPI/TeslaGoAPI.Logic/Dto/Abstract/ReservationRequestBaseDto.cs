namespace TeslaGoAPI.Logic.Dto.Abstract
{
    public record ReservationRequestBaseDto(
        DateTime StartDate,
        DateTime EndDate,
        int PickupLocationId,
        int ReturnLocationId,
        int CarModelId,
        List<int> OptServicesIds
    ) : IRequestDto;
}
