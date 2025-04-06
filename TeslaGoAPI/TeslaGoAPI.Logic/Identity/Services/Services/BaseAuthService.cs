using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using TeslaGoAPI.DB.Entities;
using TeslaGoAPI.Logic.Dto.ResponseDto;
using TeslaGoAPI.Logic.Errors;
using TeslaGoAPI.Logic.Identity.Services.Interfaces;
using TeslaGoAPI.Logic.Mapper.Extensions;
using TeslaGoAPI.Logic.Result;
using TeslaGoAPI.Logic.UnitOfWork;

namespace TeslaGoAPI.Logic.Identity.Services.Services
{
    public abstract class BaseAuthService(
        UserManager<User> userManager,
        IHttpContextAccessor httpContextAccessor,
        IUnitOfWork unitOfWork) : IBaseAuthService
    {
        protected readonly UserManager<User> _userManager = userManager;
        protected readonly IHttpContextAccessor _httpContextAccessor = httpContextAccessor;
        protected readonly IUnitOfWork _unitOfWork = unitOfWork;
        public Result<int> GetCurrentUserId()
        {
            var httpContext = _httpContextAccessor.HttpContext;
            if (httpContext == null)
                return Result<int>.Failure(AuthError.HttpContextNotAvailable);

            var userIdentity = httpContext.User.Identities.FirstOrDefault();
            if (userIdentity == null)
                return Result<int>.Failure(AuthError.CanNotConfirmIdentity);

            var userId = userIdentity.Claims.FirstOrDefault(c => c.Type == "id")?.Value;
            if (!int.TryParse(userId, out int userIdInt))
                return Result<int>.Failure(Error.ParsingError);
            if (userId == null)
                return Result<int>.Failure(AuthError.UserHaventIdClaim);

            return Result<int>.Success(userIdInt);
        }
        public async Task<IList<string>?> GetRolesForCurrentUser(User user) => await _userManager.GetRolesAsync(user);

        public async Task<Result<User>> GetCurrentUserAsEntity()
        {
            var currentUserIdResult = GetCurrentUserId();
            if (!currentUserIdResult.IsSuccessful)
                return Result<User>.Failure(currentUserIdResult.Error);

            var user = await GetOneAsync(currentUserIdResult.Value);
            if (user is null)
                return Result<User>.Failure(UserError.UserNotFound);

            if (string.IsNullOrEmpty(user.Value.Email))
                return Result<User>.Failure(UserError.UserEmailNotFound);

            return Result<User>.Success(user.Value);
        }

        public async Task<Result<UserResponseDto>> GetCurrentUser()
        {
            var getUserResult = await GetCurrentUserAsEntity();
            if (!getUserResult.IsSuccessful)
                return Result<UserResponseDto>.Failure(getUserResult.Error);

            var responseDto = MapAsDto(getUserResult.Value);

            return Result<UserResponseDto>.Success(responseDto);
        }
        private UserResponseDto MapAsDto(User entity)
        {
            var userDto = entity.AsDto<UserResponseDto>();
            userDto.EmailAddress = entity.Email!;
            userDto.UserRoles = [.. entity.Roles.Select(r => r.Name)];
            return userDto;
        }

        private async Task<Result<User>> GetOneAsync(int? id)
        {
            if (id == null)
                return Result<User>.Failure(Error.RouteParamOutOfRange);

            var _userRepository = _unitOfWork.GetRepository<User>();
            var record = await _userRepository.GetOneAsync((int)id);
            if (record == null)
                return Result<User>.Failure(Error.NotFound);

            return Result<User>.Success(record);
        }
    }
}
