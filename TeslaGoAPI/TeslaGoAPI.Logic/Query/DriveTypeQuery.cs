using TeslaGoAPI.Logic.Query.Abstract;

namespace TeslaGoAPI.Logic.Query
{
    public class DriveTypeQuery : QueryObject, INameableQuery
    {
        public string? Name { get; set; }
    }
}
