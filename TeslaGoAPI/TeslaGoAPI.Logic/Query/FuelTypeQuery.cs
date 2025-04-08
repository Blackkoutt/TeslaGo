using TeslaGoAPI.Logic.Query.Abstract;

namespace TeslaGoAPI.Logic.Query
{
    public class FuelTypeQuery : QueryObject, INameableQuery
    {
        public string? Name { get; set; }
    }
}
