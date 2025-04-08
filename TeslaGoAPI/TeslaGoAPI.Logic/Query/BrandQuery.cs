using TeslaGoAPI.Logic.Query.Abstract;

namespace TeslaGoAPI.Logic.Query
{
    public class BrandQuery : QueryObject, INameableQuery
    {
        public string? Name { get; set; }
    }
}
