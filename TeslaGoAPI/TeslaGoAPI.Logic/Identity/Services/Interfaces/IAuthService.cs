using TeslaGoAPI.DB.Entities;
using TeslaGoAPI.Logic.Dto.ResponseDto;
using TeslaGoAPI.Logic.Errors;
using TeslaGoAPI.Logic.Identity.Dto.RequestDto;
using TeslaGoAPI.Logic.Identity.Dto.ResponseDto;
using TeslaGoAPI.Logic.Result;

namespace TeslaGoAPI.Logic.Identity.Services.Interfaces
{
    public interface IAuthService : IBaseAuthService
    {
        Task<Result<UserRegisterResponseDto>> RegisterUser(UserRegisterRequestDto? requestDto);
        Task<Result<UserLoginResponseDto>> Login(UserLoginRequestDto? requestDto);
    }
}
