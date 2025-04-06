using TeslaGoAPI.Logic.Dto.ResponseDto;
using TeslaGoAPI.Logic.Identity.Enums;

namespace TeslaGoAPI.Logic.Extensions
{
    public static class UserExtensions
    {
        public static bool IsInRole(this UserResponseDto user, Roles role) =>
            user.UserRoles.Contains(role.ToString());
    }
}
