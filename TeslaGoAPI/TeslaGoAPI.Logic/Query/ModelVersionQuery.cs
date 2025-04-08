using TeslaGoAPI.Logic.Query.Abstract;

namespace TeslaGoAPI.Logic.Query
{
    public class ModelVersionQuery : QueryObject, INameableQuery
    {
        public string? Name { get; set; }
    }
}
