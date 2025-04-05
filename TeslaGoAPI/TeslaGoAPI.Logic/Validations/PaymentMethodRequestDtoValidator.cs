using FluentValidation;
using TeslaGoAPI.Logic.Dto.RequestDto;

namespace TeslaGoAPI.Logic.Validations
{
    public class PaymentMethodRequestDtoValidator : AbstractValidator<PaymentMethodRequestDto>
    {
        public PaymentMethodRequestDtoValidator()
        {
            RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Name is required.")
            .MaximumLength(60).WithMessage("Name cannot exceed 60 characters.");
        }
    }
}
