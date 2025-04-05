using FluentValidation;
using TeslaGoAPI.Logic.Dto.RequestDto;

namespace TeslaGoAPI.Logic.Validations
{
    public class CarRequestDtoValidator : AbstractValidator<CarRequestDto>
    {
        public CarRequestDtoValidator()
        {
            RuleFor(x => x.VIN)
                .NotEmpty().WithMessage("VIN is required.")
                .Length(17).WithMessage("VIN must be exactly 17 characters long.")
                .Matches("^[A-HJ-NPR-Z0-9]+$").WithMessage("VIN can only contain capital letters and digits (no I, O, Q).");

            RuleFor(x => x.RegistrationNr)
                .NotEmpty().WithMessage("Registration number is required.")
                .Length(4, 20).WithMessage("Registration number must be between 4 and 20 characters.")
                .Matches("^[A-Z0-9 ]+$").WithMessage("Registration number can only contain capital letters, digits, and spaces.");
            
            RuleFor(x => x.ModelId)
                .GreaterThan(0).WithMessage("Model ID must be greater than 0.");

            RuleFor(x => x.PaintId)
                .GreaterThan(0).WithMessage("Paint ID must be greater than 0.");

            RuleFor(x => x.LocationId)
                .GreaterThan(0).WithMessage("Location ID must be greater than 0.");
        }
    }
}
