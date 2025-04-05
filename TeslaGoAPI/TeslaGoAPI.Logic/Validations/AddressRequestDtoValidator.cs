using FluentValidation;
using TeslaGoAPI.Logic.Dto.RequestDto;

namespace TeslaGoAPI.Logic.Validations
{
    public class AddressRequestDtoValidator : AbstractValidator<AddressRequestDto>
    {
        public AddressRequestDtoValidator()
        {
            RuleFor(x => x.Street)
                .NotEmpty().WithMessage("Street is required.")
                .MaximumLength(150).WithMessage("Street cannot exceed 150 characters.");

            RuleFor(x => x.HouseNr)
                .NotEmpty().WithMessage("House number is required.")
                .MaximumLength(25).WithMessage("House number cannot exceed 25 characters.");

            RuleFor(x => x.FlatNr)
                .GreaterThan((short)0).When(x => x.FlatNr.HasValue)
                .WithMessage("Flat number must be greater than 0.")
                .LessThan((short)10000).When(x => x.FlatNr.HasValue)
                .WithMessage("Flat number cannot be greater than 10000.");


            RuleFor(x => x.ZipCode)
                .NotEmpty().WithMessage("Zip code is required.")
                .Matches(@"^[A-Za-z0-9\s\-]{3,25}$").WithMessage("Invalid zip code format.");

            RuleFor(x => x.CityId)
                .NotNull().WithMessage("City ID is required.")
                .GreaterThan(0).WithMessage("City ID must be greater than 0.");
        }
    }
}
