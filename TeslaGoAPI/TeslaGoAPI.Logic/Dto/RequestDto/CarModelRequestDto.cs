using TeslaGoAPI.Logic.Dto.Abstract;

namespace TeslaGoAPI.Logic.Dto.RequestDto
{
    public record CarModelRequestDto(
        string Name,
        byte SeatCount,
        decimal PricePerDay,
        short? Range,
        int BrandId,
        int GearBoxId,
        int FuelTypeId,
        int BodyTypeId,
        int ModelVersionId,
        int DriveTypeId,
        string? ImageName,
        CarModelDetailsRequestDto CarModelDetails,
        List<int> EquipmentsIds
    ) : IRequestDto;
}
