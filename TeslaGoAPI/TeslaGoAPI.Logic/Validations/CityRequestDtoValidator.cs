using FluentValidation;
using TeslaGoAPI.Logic.Dto.RequestDto;

namespace TeslaGoAPI.Logic.Validations
{
    public class CityRequestDtoValidator : AbstractValidator<CityRequestDto>
    {
        public CityRequestDtoValidator()
        {
            RuleFor(x => x.Name)
                    .NotEmpty().WithMessage("Name is required.")
                    .MaximumLength(80).WithMessage("Name cannot exceed 80 characters.");

            RuleFor(x => x.CountryId)
                .NotNull().WithMessage("Country ID is required.")
                .GreaterThan(0).WithMessage("Country ID must be greater than 0.");
        }
    }
}
