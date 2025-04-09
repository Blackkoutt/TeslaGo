using FluentValidation;
using TeslaGoAPI.Logic.Dto.RequestDto;

namespace TeslaGoAPI.Logic.Validations
{
    public class CarModelDetailsRequestDtoValidator : AbstractValidator<CarModelDetailsRequestDto>
    {
        public CarModelDetailsRequestDtoValidator()
        {
          
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
        }
    }
}
