using TeslaGoAPI.Logic.Query.Abstract;

namespace TeslaGoAPI.Logic.Query
{
    public class PaintQuery : QueryObject, INameableQuery
    {
        public string? Name { get; set; }
        public string? Hex { get; set; }
    }
}
