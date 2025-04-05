using FluentValidation;
using TeslaGoAPI.Logic.Dto.RequestDto;

namespace TeslaGoAPI.Logic.Validations
{
    public class DriveTypeRequestDtoValidator : AbstractValidator<DriveTypeRequestDto>
    {
        public DriveTypeRequestDtoValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Name is required.")
                .MaximumLength(80).WithMessage("Name cannot exceed 80 characters.");

            RuleFor(x => x.Description)
                .MaximumLength(500).WithMessage("Description cannot exceed 500 characters.");
        }
    }
}
