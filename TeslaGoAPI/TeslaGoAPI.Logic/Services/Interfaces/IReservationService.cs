using TeslaGoAPI.DB.Entities;
using TeslaGoAPI.Logic.Dto.RequestDto;
using TeslaGoAPI.Logic.Dto.ResponseDto;
using TeslaGoAPI.Logic.Dto.UpdateRequestDto;
using TeslaGoAPI.Logic.Query;
using TeslaGoAPI.Logic.Services.Interfaces.Abstract;

namespace TeslaGoAPI.Logic.Services.Interfaces
{
    public interface IReservationService : IGenericService<
        Reservation,
        ReservationRequestDto,
        ReservationUpdateRequestDto,
        ReservationResponseDto,
        ReservationQuery
    >
    {
        void AssignCarToReservation(Reservation res, Car car);
        Task<IEnumerable<Car>> GetCarsAvailableInSelectedDateRange(int modelId, DateTime startDate, DateTime endDate, int? resId = null);
        IEnumerable<Car> GetAvailableCarsInLocation(IEnumerable<Car> allAvailableCars, DateTime startDate, int locationId);
        Task<IEnumerable<Reservation>> GetReservationsWithoutAssingedCarForRange(DateTime startRange, DateTime endRange);
    }
}
