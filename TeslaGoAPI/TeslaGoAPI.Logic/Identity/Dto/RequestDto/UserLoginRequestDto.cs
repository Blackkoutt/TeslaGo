using TeslaGoAPI.Logic.Dto.Abstract;

namespace TeslaGoAPI.Logic.Identity.Dto.RequestDto
{
    public record UserLoginRequestDto(
        string Email,
        string Password) : IRequestDto;
}
