using FluentValidation;
using TeslaGoAPI.Logic.Dto.RequestDto;

namespace TeslaGoAPI.Logic.Validations
{
    public class BodyTypeRequestDtoValidator : AbstractValidator<BodyTypeRequestDto>
    {
        public BodyTypeRequestDtoValidator()
        {
            RuleFor(x => x.Name)
                    .NotEmpty().WithMessage("Name is required.")
                    .MaximumLength(80).WithMessage("Name cannot exceed 80 characters.");
        }
    }
}
