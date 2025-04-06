using TeslaGoAPI.DB.Entities;

namespace TeslaGoAPI.Logic.Identity.Services.Interfaces
{
    public interface IJWTGeneratorService
    {
        string GenerateToken(User user, IList<string>? roles);
    }
}
