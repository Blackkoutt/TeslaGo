using TeslaGoAPI.Logic.Dto.Abstract;

namespace TeslaGoAPI.Logic.Dto.ResponseDto
{
    public class AddressResponseDto : BaseResponseDto
    {
        public string Street { get; set; } = string.Empty;
        public string HouseNr { get; set; } = string.Empty;
        public short? FlatNr { get; set; }
        public string ZipCode { get; set; } = string.Empty;
        public CityResponseDto City { get; set; } = default!;
    }
}
