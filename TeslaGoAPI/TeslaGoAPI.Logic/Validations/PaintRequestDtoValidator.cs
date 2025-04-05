using FluentValidation;
using TeslaGoAPI.Logic.Dto.RequestDto;

namespace TeslaGoAPI.Logic.Validations
{
    public class PaintRequestDtoValidator : AbstractValidator<PaintRequestDto>
    {
        public PaintRequestDtoValidator()
        {
            RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Name is required.")
            .MaximumLength(50).WithMessage("Name cannot exceed 50 characters.");

            RuleFor(x => x.ColorHex)
                .NotEmpty().WithMessage("Color hex code is required.")
                .Matches(@"^#([A-Fa-f0-9]{6})$").WithMessage("Color hex must be in the format '#RRGGBB'.");
        }
    }
}
