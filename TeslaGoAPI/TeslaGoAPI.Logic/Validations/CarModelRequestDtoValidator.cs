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
