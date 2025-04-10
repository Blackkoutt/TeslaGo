using TeslaGoAPI.DB.Entities;
using TeslaGoAPI.Logic.Dto.RequestDto;
using TeslaGoAPI.Logic.Dto.ResponseDto;
using TeslaGoAPI.Logic.Query;
using TeslaGoAPI.Logic.Result;
using TeslaGoAPI.Logic.Services.Interfaces.Abstract;

namespace TeslaGoAPI.Logic.Services.Interfaces
{
    public interface IUserService : IGenericService<
        User,
        UserRequestDto,
        UserRequestDto,
        UserResponseDto,
        UserQuery
    >
    {
        Task<Result<object>> SetUserInfo(UserDataRequestDto userDataRequestDto);
    }
}
