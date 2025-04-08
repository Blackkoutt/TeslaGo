using TeslaGoAPI.Logic.Query.Abstract;

namespace TeslaGoAPI.Logic.Query
{
    public class CarModelQuery : QueryObject, INameableQuery
    {
        public string? Name { get; set; }
        public decimal? MinPrice { get; set; }
        public decimal? MaxPrice { get; set; }
        public short? MinRange { get; set; }
        public short? MaxRange { get; set; }
        public int? BrandId { get; set; }
        public int? GearBoxId { get; set; }
        public int? FuelTypeId { get; set; }
        public int? BodyTypeId { get; set; }
        public int? ModelVersionId { get; set; }
        public int? DriveTypeId { get; set; }
        public short? MinHorsePower { get; set; }
        public short? MaxHorsePower { get; set; }
        public int? MinTrunkCapacityLiters { get; set; }
        public int? MaxTrunkCapacityLiters { get; set; }
    }
}
