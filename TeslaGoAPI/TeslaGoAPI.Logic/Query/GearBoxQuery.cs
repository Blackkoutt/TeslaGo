using TeslaGoAPI.Logic.Query.Abstract;

namespace TeslaGoAPI.Logic.Query
{
    public class GearBoxQuery : QueryObject, INameableQuery
    {
        public string? Name { get; set; }
    }
}
