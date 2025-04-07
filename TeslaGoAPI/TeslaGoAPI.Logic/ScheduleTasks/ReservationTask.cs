using Coravel.Invocable;
using Serilog;
using TeslaGoAPI.DB.Entities;
using TeslaGoAPI.Logic.Services.Interfaces;
using TeslaGoAPI.Logic.UnitOfWork;

namespace TeslaGoAPI.Logic.Schedulers
{
    public class ReservationTask(IUnitOfWork unitOfWork, IReservationService resService) : IInvocable
    {
        private readonly IUnitOfWork _unitOfWork = unitOfWork;
        private readonly IReservationService _resService = resService;

        public async Task Invoke()
        {
            Log.Information("Starts performing reservation update");

            var currentDate = DateTime.Now;
            var twoDaysLater = currentDate.AddHours(48);

            var resWithoutCar = await _resService.GetReservationsWithoutAssingedCarForRange(currentDate, twoDaysLater);
            
            if (resWithoutCar.Any())
            {
                Log.Information("Reservations to update: {@reservationsIds}", resWithoutCar.Select(x => x.Id));
                foreach(var res in resWithoutCar)
                {
                    var allAvailableCars = await _resService.GetCarsAvailableInSelectedDateRange(res.CarModelId, res.StartDate, res.EndDate);
                    var availableCarsInLocation = _resService.GetAvailableCarsInLocation(allAvailableCars, res.StartDate, res.PickupLocationId);

                    if (availableCarsInLocation.Any())
                    {
                        var car = availableCarsInLocation.First();
                        _resService.AssignCarToReservation(res, car);
                        _unitOfWork.GetRepository<Reservation>().Update(res);
                    }
                    else
                    {
                        var carsInLocations = GroupCarsByLocation(allAvailableCars, res.StartDate);
                        LogWarningAboutLackOfCars(res, carsInLocations);
                        await SaveInfoAboutLackOfCarsInDb(res);
                    }

                }
                await _unitOfWork.SaveChangesAsync();
            }
            else Log.Information("No reservations to update");

            Log.Information("End performing reservation update");
        }

        private async Task SaveInfoAboutLackOfCarsInDb(Reservation res)
        {
            var availabilityIssue = new CarAvailabilityIssue
            {
                IssueDetectionDate = DateTime.Now,
                ReservationId = res.Id,
                CarModelId = res.CarModelId,
                LocationId = res.PickupLocationId
            };
            await _unitOfWork.GetRepository<CarAvailabilityIssue>().AddAsync(availabilityIssue);
        }

        private void LogWarningAboutLackOfCars(Reservation res, IEnumerable<IGrouping<string?, Car>> carsInLocations)
        {
            Log.Warning("No available cars for given car model in selected location");
            Log.Warning($"Car Model: {res.CarModel.Brand} {res.CarModel.Name} {res.CarModel.ModelVersion} {res.CarModel.DriveType} in location {res.PickupLocation.Name}");
            Log.Information($"Locations where car model is available: {string.Join(", ", carsInLocations.Select(x => $"{x.Key} ({x.Count()})"))}");
        }

        private IEnumerable<IGrouping<string?, Car>> GroupCarsByLocation(IEnumerable<Car> cars, DateTime resStartDate)
        {
            return cars.GroupBy(car =>
            {
                return car.Locations
                    .OrderByDescending(l => l.FromDate)
                    .FirstOrDefault(l => l.FromDate <= resStartDate)?.Location.Name;
            });
        }
    }
}
