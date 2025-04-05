using FluentValidation;
using TeslaGoAPI.Logic.Dto.RequestDto;

namespace TeslaGoAPI.Logic.Validations
{
    public class GearBoxRequestDtoValidator : AbstractValidator<GearBoxRequestDto>
    {
        public GearBoxRequestDtoValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Name is required.")
                .MaximumLength(80).WithMessage("Name cannot exceed 80 characters.");

            RuleFor(x => x.NumberOfGears)
                .GreaterThan((byte)0).When(x => x.NumberOfGears.HasValue)
                .WithMessage("NumberOfGears must be greater than 0.")
                .LessThan((byte)10).When(x => x.NumberOfGears.HasValue)
                .WithMessage("NumberOfGears cannot be greater than 10.");
        }
    }
}
