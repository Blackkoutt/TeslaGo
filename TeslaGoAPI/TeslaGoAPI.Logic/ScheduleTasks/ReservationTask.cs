using Coravel.Invocable;
using Serilog;
using TeslaGoAPI.DB.Entities;
using TeslaGoAPI.Logic.UnitOfWork;

namespace TeslaGoAPI.Logic.Schedulers
{
    public class ReservationTask(IUnitOfWork unitOfWork) : IInvocable
    {
        private readonly IUnitOfWork _unitOfWork = unitOfWork;

        public async Task Invoke()
        {
            Log.Information("Starts performing reservation update");

            var reservationsWithoutAssignedCar = await GetReservationsForNextTwoDays();
            
            if (reservationsWithoutAssignedCar.Any())
            {
                Log.Information("Reservations to update: {@reservationsIds}", reservationsWithoutAssignedCar.Select(x => x.Id));
                foreach(var res in reservationsWithoutAssignedCar)
                {
                    var allAvailableCars = await GetAvailableCars(res.CarModelId, res.StartDate, res.EndDate);
                    var availableCarsInLocation = GetAvailableCarsInLocation(allAvailableCars, res.StartDate, res.PickupLocationId);

                    if (availableCarsInLocation.Any())
                    {
                        var car = availableCarsInLocation.First();
                        AssignConcreteCarToReservation(res, car);
                    }
                    else
                    {
                        var carsInLocations = allAvailableCars.GroupBy(car =>
                        {
                            return car.Locations
                                .OrderByDescending(l => l.FromDate)
                                .FirstOrDefault(l => l.FromDate <= res.StartDate)?.Location.Name;
                        });

                        Log.Warning("No available cars for given car model in selected location");
                        Log.Warning($"Car Model: {res.CarModel.Brand} {res.CarModel.Name} {res.CarModel.ModelVersion} {res.CarModel.DriveType} in location {res.PickupLocation.Name}");
                        Log.Information($"Locations where car model is available: {string.Join(", ", carsInLocations.Select(x => $"{x.Key} ({x.Count()})"))}");

                        var availabilityIssue = new CarAvailabilityIssue
                        {
                            IssueDetectionDate = DateTime.Now,
                            ReservationId = res.Id,
                            CarModelId = res.CarModelId,
                            LocationId = res.PickupLocationId
                        };
                        await _unitOfWork.GetRepository<CarAvailabilityIssue>().AddAsync(availabilityIssue);
                    }

                }
                await _unitOfWork.SaveChangesAsync();
            }
            else Log.Information("No reservations to update");

            Log.Information("End performing reservation update");
        }

        private async Task<IEnumerable<Reservation>> GetReservationsForNextTwoDays()
        {
            var currentDate = DateTime.Now;
            var twoDaysLater = currentDate.AddHours(48);

            var reservations = _unitOfWork.GetRepository<Reservation>()
                .GetAllAsync(q => q.Where(reservation =>
                    reservation.CarId == null &&
                    reservation.StartDate >= currentDate &&
                    reservation.StartDate <= twoDaysLater));

            return await reservations;
        }

        private async Task<IEnumerable<Car>> GetAvailableCars(int carModelId, DateTime startDate, DateTime endDate)
        {
            return await _unitOfWork.GetRepository<Car>()
                .GetAllAsync(q => q.Where(x =>
                    x.ModelId == carModelId &&
                    !x.Reservations.Any(x =>
                        x.StartDate <= endDate &&
                        x.EndDate >= startDate)));
        }
        private IEnumerable<Car> GetAvailableCarsInLocation(IEnumerable<Car> allAvailableCars, DateTime startDate, int locationId)
        {
            return allAvailableCars.Where(car =>
            {
                var lastLocation = car.Locations
                    .OrderByDescending(l => l.FromDate)
                    .FirstOrDefault(l => l.FromDate <= startDate);

                return lastLocation != null && lastLocation.LocationId == locationId;
            });
        }

        private void AssignConcreteCarToReservation(Reservation res, Car car)
        {
            res.CarId = car.Id;

            car.Locations.Add(new Car_Location
            {
                CarId = car.Id,
                LocationId = res.ReturnLocationId,
                FromDate = res.EndDate,
            });

            _unitOfWork.GetRepository<Car>().Update(car);
            _unitOfWork.GetRepository<Reservation>().Update(res);
        }
    }
}
