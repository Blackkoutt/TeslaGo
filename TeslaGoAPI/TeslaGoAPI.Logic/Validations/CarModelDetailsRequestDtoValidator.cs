using FluentValidation;
using TeslaGoAPI.Logic.Dto.RequestDto;

namespace TeslaGoAPI.Logic.Validations
{
    public class CarModelDetailsRequestDtoValidator : AbstractValidator<CarModelDetailsRequestDto>
    {
        public CarModelDetailsRequestDtoValidator()
        {
            RuleFor(x => x.DoorCount)
                .InclusiveBetween((byte)2, (byte)10)
                .When(x => x.DoorCount.HasValue)
                .WithMessage("Door count must be between 2 and 10.");

            RuleFor(x => x.HorsePower)
                .InclusiveBetween((short)1, (short)10000)
                .When(x => x.HorsePower.HasValue)
                .WithMessage("Horse power must be between 1 and 10000.");

            RuleFor(x => x.ProductionStartYear)
                .LessThanOrEqualTo(DateTime.Today)
                .When(x => x.ProductionStartYear.HasValue)
                .WithMessage("Production start year cannot be in the future.");

            RuleFor(x => x.ProductionEndYear)
                .GreaterThan(x => x.ProductionStartYear!.Value)
                .When(x => x.ProductionEndYear.HasValue && x.ProductionStartYear.HasValue)
                .WithMessage("Production end year must be after the start year.");

            RuleFor(x => x.Description)
                .MaximumLength(1000)
                .When(x => !string.IsNullOrWhiteSpace(x.Description))
                .WithMessage("Description cannot exceed 1000 characters.");

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
        }
    }
}
