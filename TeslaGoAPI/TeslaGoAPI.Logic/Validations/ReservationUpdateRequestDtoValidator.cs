using FluentValidation;
using TeslaGoAPI.Logic.Dto.RequestDto;
using TeslaGoAPI.Logic.Dto.UpdateRequestDto;

namespace TeslaGoAPI.Logic.Validations
{
    public class ReservationUpdateRequestDtoValidator : AbstractValidator<ReservationUpdateRequestDto>
    {
        public ReservationUpdateRequestDtoValidator()
        {
            RuleFor(x => x.StartDate)
                .GreaterThanOrEqualTo(DateTime.Today).WithMessage("Start date cannot be in the past.");

            RuleFor(x => x.EndDate)
                .GreaterThan(x => x.StartDate).WithMessage("End date must be after start date.");

            RuleFor(x => x.PickupLocationId)
                .GreaterThan(0).WithMessage("Pickup location ID must be greater than 0.");

            RuleFor(x => x.ReturnLocationId)
                .GreaterThan(0).WithMessage("Return location ID must be greater than 0.");

            RuleFor(x => x.CarModelId)
                .GreaterThan(0).WithMessage("Model ID must be greater than 0.");

            RuleFor(x => x.CarId)
                .GreaterThan(0).WithMessage("Car ID must be greater than 0.");

            RuleFor(x => x.OptServicesIds)
                .Must(ids => ids.Distinct().Count() == ids.Count)
                .WithMessage("Optional services cannot contain duplicates.")
                .ForEach(id => id
                    .GreaterThan(0).WithMessage("Optional service IDs must be greater than 0.")
                );
        }
    }
}
