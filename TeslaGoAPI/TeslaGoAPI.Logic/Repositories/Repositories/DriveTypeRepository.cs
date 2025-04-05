using TeslaGoAPI.DB.Context;
using TeslaGoAPI.Logic.Repositories.Repositories.Abstract;

namespace TeslaGoAPI.Logic.Repositories.Repositories
{
    public sealed class DriveTypeRepository(APIContext context) : GenericRepository<DB.Entities.DriveType>(context)
    {
    }
}
