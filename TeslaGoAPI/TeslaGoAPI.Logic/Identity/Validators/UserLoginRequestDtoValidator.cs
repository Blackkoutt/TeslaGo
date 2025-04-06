using FluentValidation;
using TeslaGoAPI.Logic.Identity.Dto.RequestDto;

namespace TeslaGoAPI.Logic.Identity.Validators
{
    public class LoginRequestDtoValidator : AbstractValidator<UserLoginRequestDto>
    {
        public LoginRequestDtoValidator()
        {
            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("Email is required.")
                .EmailAddress().WithMessage("Invalid email format.");

            RuleFor(x => x.Password)
                .NotEmpty().WithMessage("Password is required.");
        }
    }
}
