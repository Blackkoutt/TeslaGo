using TeslaGoAPI.Logic.Dto.Abstract;

namespace TeslaGoAPI.Logic.Dto.RequestDto
{
    public record CarModelDetailsRequestDto(
        byte? DoorCount,
        short? HorsePower,
        DateTime? ProductionStartYear,
        DateTime? ProductionEndYear,
        string? Description,
        decimal? AccelerationInSeconds,
        short? MaxSpeedInKmPerHour,
        int? TrunkCapacityLiters,
        int? TrunkCapacitySuitCases
    ) : IRequestDto;
}
