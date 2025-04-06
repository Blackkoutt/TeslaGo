using FluentValidation;
using TeslaGoAPI.Logic.Identity.Dto.RequestDto;

namespace TeslaGoAPI.Logic.Identity.Validators
{
    public class UserRegisterRequestDtoValidator : AbstractValidator<UserRegisterRequestDto>
    {
        public UserRegisterRequestDtoValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Name is required.")
                .MaximumLength(60).WithMessage("Name cannot exceed 60 characters.");

            RuleFor(x => x.Surname)
                .NotEmpty().WithMessage("Surname is required.")
                .MaximumLength(80).WithMessage("Surname cannot exceed 80 characters.");

            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("Email is required.")
                .EmailAddress().WithMessage("Invalid email format.");

            RuleFor(x => x.DateOfBirth)
                .LessThan(DateTime.Today.AddYears(-18)).WithMessage("User must be at least 18 years old.");

            RuleFor(x => x.Password)
                .NotEmpty().WithMessage("Password is required.")
                .MinimumLength(8).WithMessage("Password must be at least 8 characters long.")
                .Matches("[A-Z]").WithMessage("Password must contain at least one uppercase letter.")
                .Matches("[a-z]").WithMessage("Password must contain at least one lowercase letter.")
                .Matches("[0-9]").WithMessage("Password must contain at least one number.");

            RuleFor(x => x.ConfirmPassword)
                .Equal(x => x.Password).WithMessage("Password and Confirm Password must match.");
        }
    }
}
