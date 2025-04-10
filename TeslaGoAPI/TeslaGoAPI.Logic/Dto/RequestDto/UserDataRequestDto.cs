using TeslaGoAPI.Logic.Dto.Abstract;

namespace TeslaGoAPI.Logic.Dto.RequestDto
{
    public record UserDataRequestDto(
        string? Street,
        string? HouseNumber,
        short? FlatNumber,
        string? City,
        string? ZipCode,
        int? CountryId,
        string? DrivingLicenseNumber) : IRequestDto;
}
