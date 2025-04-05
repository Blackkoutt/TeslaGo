using FluentValidation;
using TeslaGoAPI.Logic.Dto.RequestDto;

namespace TeslaGoAPI.Logic.Validations
{
    public class BrandRequestDtoValidator : AbstractValidator<BrandRequestDto>
    {
        public BrandRequestDtoValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Name is required.")
                .MaximumLength(80).WithMessage("Name cannot exceed 80 characters.");
        }
    }
}
