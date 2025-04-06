using TeslaGoAPI.Logic.Dto.Abstract;

namespace TeslaGoAPI.Logic.Identity.Dto.RequestDto
{
    public record UserRegisterRequestDto(
        string Name,
        string Surname,
        string Email,
        DateTime DateOfBirth,
        string Password,
        string ConfirmPassword) : IRequestDto;
}
