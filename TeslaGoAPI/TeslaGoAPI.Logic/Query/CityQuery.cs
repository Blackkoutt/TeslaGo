using TeslaGoAPI.Logic.Query.Abstract;

namespace TeslaGoAPI.Logic.Query
{
    public class CityQuery : QueryObject, INameableQuery
    {
        public string? Name { get; set; }
        public string? CountryName { get; set; }
        public int? CountryId { get; set; }
    }
}
