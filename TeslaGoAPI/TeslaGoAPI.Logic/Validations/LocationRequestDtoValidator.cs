using FluentValidation;
using TeslaGoAPI.Logic.Dto.RequestDto;

namespace TeslaGoAPI.Logic.Validations
{
    public class LocationRequestDtoValidator : AbstractValidator<LocationRequestDto>
    {
        public LocationRequestDtoValidator()
        {

            RuleFor(x => x.Name)
                    .NotEmpty().WithMessage("Name is required.")
                    .MaximumLength(150).WithMessage("Name cannot exceed 150 characters.");

            RuleFor(x => x.AddressId)
                .NotNull().WithMessage("Address ID is required.")
                .GreaterThan(0).WithMessage("Address ID must be greater than 0.");
        }
    }
}
