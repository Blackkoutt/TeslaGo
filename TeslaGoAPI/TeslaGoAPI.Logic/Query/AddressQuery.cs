using TeslaGoAPI.Logic.Query.Abstract;

namespace TeslaGoAPI.Logic.Query
{
    public class AddressQuery : QueryObject
    {
        public string? Street { get; set; }
        public string? HouseNr { get; set; }
        public short? FlatNr { get; set; }
        public string? ZipCode { get; set; }
        public int? CityId { get; set; }
    }
}
