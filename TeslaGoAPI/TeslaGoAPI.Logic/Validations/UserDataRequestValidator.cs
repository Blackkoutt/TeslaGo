using FluentValidation;
using TeslaGoAPI.Logic.Dto.RequestDto;

namespace TeslaGoAPI.Logic.Validations
{
    public class UserDataRequestDtoValidator : AbstractValidator<UserDataRequestDto>
    {
        public UserDataRequestDtoValidator()
        {
            RuleFor(x => x.Street)
             .MaximumLength(150).WithMessage("Street cannot exceed 150 characters.")
             .MinimumLength(2).When(x => !string.IsNullOrWhiteSpace(x.Street)).WithMessage("Street: min 2 chars.");

            RuleFor(x => x.HouseNumber)
                .MaximumLength(25).When(x => !string.IsNullOrWhiteSpace(x.HouseNumber)).WithMessage("House number cannot exceed 25 characters.");

            RuleFor(x => x.FlatNumber)
                .InclusiveBetween((short)1, (short)10000).When(x => x.FlatNumber.HasValue)
                .WithMessage("Flat no: 1–999.");

            RuleFor(x => x.ZipCode)
                .Matches(@"^[A-Za-z0-9\s\-]{3,25}$").When(x => !string.IsNullOrWhiteSpace(x.ZipCode)).WithMessage("Invalid zip code format.");

            RuleFor(x => x.City)
                .MaximumLength(80).When(x => !string.IsNullOrWhiteSpace(x.City)).WithMessage("Name cannot exceed 80 characters.");

            RuleFor(x => x.CountryId)
                .GreaterThan(0).When(x => x.CountryId.HasValue).WithMessage("Country ID must be greater than 0.");

            RuleFor(x => x.DrivingLicenseNumber)
                .MaximumLength(30).WithMessage("DrivingLicenseNumber: max 30 chars.")
                .MinimumLength(2).When(x => !string.IsNullOrWhiteSpace(x.DrivingLicenseNumber)).WithMessage("DrivingLicenseNumber: min 2 chars.");
        }
    }
}
