using FluentValidation;
using TeslaGoAPI.Logic.Dto.RequestDto;

namespace TeslaGoAPI.Logic.Validations
{
    public class CarModelRequestDtoValidator : AbstractValidator<CarModelRequestDto>
    {
        public CarModelRequestDtoValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Model name is required.")
                .MaximumLength(150).WithMessage("Model name cannot exceed 150 characters.");

            RuleFor(x => x.SeatCount)
                .InclusiveBetween((byte)1, (byte)25)
                .WithMessage("Seat count must be between 1 and 25.");

            RuleFor(x => x.PricePerDay)
                .InclusiveBetween(0m, 50000m)
                .WithMessage("Price per day must be between 0 and 50000.");

            RuleFor(x => x.Range)
                .InclusiveBetween((short)0, (short)10000)
                .When(x => x.Range.HasValue)
                .WithMessage("Range must be between 0 and 10000.");

            RuleFor(x => x.DoorCount)
               .InclusiveBetween((byte)2, (byte)10)
               .When(x => x.DoorCount.HasValue)
               .WithMessage("Door count must be between 2 and 10.");

            RuleFor(x => x.HorsePower)
                .InclusiveBetween((short)1, (short)10000)
                .When(x => x.HorsePower.HasValue)
                .WithMessage("Horse power must be between 1 and 10000.");

            RuleFor(x => x.AccelerationInSeconds)
              .InclusiveBetween(0m, 1000m)
              .When(x => x.AccelerationInSeconds.HasValue)
              .WithMessage("Acceleration must be greater than 0s.");

            RuleFor(x => x.MaxSpeedInKmPerHour)
                .InclusiveBetween((short)1, (short)1000)
                .When(x => x.MaxSpeedInKmPerHour.HasValue)
                .WithMessage("Max speed must be greater than 1 km/h.");

            RuleFor(x => x.TrunkCapacityLiters)
                .InclusiveBetween(0, 10000)
                .When(x => x.TrunkCapacityLiters.HasValue)
                .WithMessage("Trunk capacity (liters) must be between 0 and 10000.");

            RuleFor(x => x.TrunkCapacitySuitCases)
                .InclusiveBetween(0, 50)
                .When(x => x.TrunkCapacitySuitCases.HasValue)
                .WithMessage("Trunk capacity (suitcases) must be between 0 and 50.");

            RuleFor(x => x.BrandId)
                .GreaterThan(0).WithMessage("Brand ID must be greater than 0.");

            RuleFor(x => x.GearBoxId)
                .GreaterThan(0).WithMessage("Gearbox ID must be greater than 0.");

            RuleFor(x => x.FuelTypeId)
                .GreaterThan(0).WithMessage("Fuel type ID must be greater than 0.");

            RuleFor(x => x.BodyTypeId)
                .GreaterThan(0).WithMessage("Body type ID must be greater than 0.");

            RuleFor(x => x.ModelVersionId)
                .GreaterThan(0).WithMessage("Model version ID must be greater than 0.");

            RuleFor(x => x.DriveTypeId)
                .GreaterThan(0).WithMessage("Drive type ID must be greater than 0.");

            RuleFor(x => x.CarModelDetails)
                .NotNull().WithMessage("Car model details are required.")
                .SetValidator(new CarModelDetailsRequestDtoValidator());

            RuleFor(x => x.EquipmentsIds)
                .NotNull().WithMessage("Equipment list must be provided.")
                .Must(ids => ids.Distinct().Count() == ids.Count)
                .WithMessage("Equipment list cannot contain duplicates.")
                .ForEach(id => id
                    .GreaterThan(0).WithMessage("Equipment ID must be greater than 0.")
                );
        }
    }
}
