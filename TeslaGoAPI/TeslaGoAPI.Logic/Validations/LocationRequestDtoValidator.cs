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

            RuleFor(x => x.AddressRequestDto)
                .NotNull().WithMessage("Address is required.")
                .SetValidator(new AddressRequestDtoValidator());
        }
    }
}
