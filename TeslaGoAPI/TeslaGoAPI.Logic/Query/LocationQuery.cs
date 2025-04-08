using TeslaGoAPI.Logic.Query.Abstract;

namespace TeslaGoAPI.Logic.Query
{
    public class LocationQuery : QueryObject, INameableQuery
    {
        public string? Name { get; set; }
        public string? Street { get; set; }
        public string? CityName { get; set; }
        public int? CityId { get; set; }
        public int? CountryId { get; set; }
        public string? CountryName { get; set; }
    }
}
