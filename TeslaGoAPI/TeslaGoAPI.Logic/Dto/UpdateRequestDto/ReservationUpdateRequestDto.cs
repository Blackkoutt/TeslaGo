using TeslaGoAPI.Logic.Dto.Abstract;

namespace TeslaGoAPI.Logic.Dto.UpdateRequestDto
{
    public record ReservationUpdateRequestDto(
        DateTime StartDate,
        DateTime EndDate,
        int PickupLocationId,
        int ReturnLocationId,
        int CarModelId,
        int? CarId,
        List<int> OptServicesIds
    ) : ReservationRequestBaseDto(StartDate, EndDate, PickupLocationId, ReturnLocationId, CarModelId, OptServicesIds);
}
