using TeslaGoAPI.DB.Entities;
using TeslaGoAPI.Logic.Dto.ResponseDto;

namespace TeslaGoAPI.Logic.Helpers
{
    public record ReservationValidateWrapper(
        CarModel CarModel,
        IEnumerable<OptService> OptServices,
        UserResponseDto User,
        Location PickupLocation,
        Location ReturnLocation,
        Reservation? Reservation
        );
    
}
