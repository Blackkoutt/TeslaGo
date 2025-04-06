using TeslaGoAPI.Logic.Dto.Abstract;

namespace TeslaGoAPI.Logic.Dto.RequestDto
{
    public record ReservationRequestDto(
        DateTime StartDate,
        DateTime EndDate,
        int PickupLocationId,
        int ReturnLocationId,
        int CarModelId,
        int PaymentMethodId,
        List<int> OptServicesIds
    ) : IRequestDto;
}
