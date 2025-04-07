using Serilog;
using System;
using TeslaGoAPI.DB.Entities;
using TeslaGoAPI.Logic.Dto.ResponseDto;
using TeslaGoAPI.Logic.Identity.Enums;

namespace TeslaGoAPI.Logic.Extensions
{
    public static class UserExtensions
    {
        public static bool IsInRole(this UserResponseDto user, Roles role) =>
            user.UserRoles.Contains(role.ToString());

        public static bool IsInRole(this User user, Roles role)
        {
            return user.Roles.Any(x => string.Equals(x.Name, role.ToString(), StringComparison.OrdinalIgnoreCase));
        }
    }
}
