using TeslaGoAPI.Logic.Query.Abstract;

namespace TeslaGoAPI.Logic.Query
{
    public class EquipmentQuery : QueryObject, INameableQuery
    {
        public string? Name { get; set; }
    }
}
