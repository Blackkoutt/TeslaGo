using TeslaGoAPI.Logic.Query.Abstract;

namespace TeslaGoAPI.Logic.Query
{
    public class CountryQuery : QueryObject, INameableQuery
    {
        public string? Name { get; set; }
    }
}
