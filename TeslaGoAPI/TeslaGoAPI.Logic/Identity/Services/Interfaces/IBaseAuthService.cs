using TeslaGoAPI.DB.Entities;
using TeslaGoAPI.Logic.Dto.ResponseDto;
using TeslaGoAPI.Logic.Result;

namespace TeslaGoAPI.Logic.Identity.Services.Interfaces
{
    public interface IBaseAuthService
    {
        Task<Result<User>> GetCurrentUserAsEntity();
        Task<Result<UserResponseDto>> GetCurrentUser();
        Result<int> GetCurrentUserId();
        Task<IList<string>?> GetRolesForCurrentUser(User user);
    }
}
