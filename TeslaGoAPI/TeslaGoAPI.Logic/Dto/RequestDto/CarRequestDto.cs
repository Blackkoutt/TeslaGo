using TeslaGoAPI.Logic.Dto.Abstract;

namespace TeslaGoAPI.Logic.Dto.RequestDto
{
    public record CarRequestDto(
       string VIN,
       string RegistrationNr,
       int ModelId,
       int PaintId,
       int LocationId
    ) : IRequestDto;
}
