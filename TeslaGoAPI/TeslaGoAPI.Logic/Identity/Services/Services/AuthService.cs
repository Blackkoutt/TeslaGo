using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using TeslaGoAPI.DB.Entities;
using TeslaGoAPI.Logic.Errors;
using TeslaGoAPI.Logic.Identity.Dto.RequestDto;
using TeslaGoAPI.Logic.Identity.Dto.ResponseDto;
using TeslaGoAPI.Logic.Identity.Enums;
using TeslaGoAPI.Logic.Identity.Services.Interfaces;
using TeslaGoAPI.Logic.Mapper.Extensions;
using TeslaGoAPI.Logic.Result;
using TeslaGoAPI.Logic.UnitOfWork;

namespace TeslaGoAPI.Logic.Identity.Services.Services
{
    public class AuthService(
        UserManager<User> userManager,
        IUnitOfWork unitOfWork,
        IHttpContextAccessor httpContextAccessor,
        IJWTGeneratorService jwtGeneratorService) : BaseAuthService(userManager, httpContextAccessor, unitOfWork), IAuthService
    {
        private readonly IJWTGeneratorService _jwtGeneratorService = jwtGeneratorService;

        public async Task<Result<UserRegisterResponseDto>> RegisterUser(UserRegisterRequestDto? requestDto)
        {
            if (requestDto == null)
                return Result<UserRegisterResponseDto>.Failure(Error.NullParameter);

            var isUserWithSameEmailExistInDB = await _userManager.FindByEmailAsync(requestDto.Email);
            if (isUserWithSameEmailExistInDB != null)
                return Result<UserRegisterResponseDto>.Failure(AuthError.EmailAlreadyTaken);

            var user = requestDto.AsEntity<User>();
            user.RegisteredDate = DateTime.Now;

            var result = await _userManager.CreateAsync(user, requestDto.Password);
            if (!result.Succeeded)
            {
                var errors = result.Errors.ToDictionary(e => e.Code, e => e.Description);
                return Result<UserRegisterResponseDto>.Failure(new AuthError(errors).ErrorsWhileCreatingUser);
            }

            await _userManager.AddToRoleAsync(user, Roles.User.ToString());

            var roles = new List<string> { Roles.User.ToString() };

            var responseDto = new UserRegisterResponseDto(_jwtGeneratorService.GenerateToken(user, roles));

            return Result<UserRegisterResponseDto>.Success(responseDto);
        }

        public async Task<Result<UserLoginResponseDto>> Login(UserLoginRequestDto? requestDto)
        {
            if (requestDto == null)
                return Result<UserLoginResponseDto>.Failure(Error.NullParameter);

            var user = await _userManager.FindByEmailAsync(requestDto.Email);
            if (user == null || !await _userManager.CheckPasswordAsync(user, requestDto.Password))
                return Result<UserLoginResponseDto>.Failure(AuthError.InvalidEmailOrPassword);

            var roles = await GetRolesForCurrentUser(user);

            var responseDto = new UserLoginResponseDto(_jwtGeneratorService.GenerateToken(user, roles));

            return Result<UserLoginResponseDto>.Success(responseDto);
        }

    }
}
