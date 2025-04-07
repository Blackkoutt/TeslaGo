using TeslaGoAPI.DB.Entities;
using TeslaGoAPI.Logic.Dto.RequestDto;
using TeslaGoAPI.Logic.Dto.ResponseDto;
using TeslaGoAPI.Logic.Query;
using TeslaGoAPI.Logic.Services.Interfaces.Abstract;

namespace TeslaGoAPI.Logic.Services.Interfaces
{
    public interface ICarService : IGenericService<
        Car,
        CarRequestDto,
        CarRequestDto,
        CarResponseDto,
        CarQuery
    >
    {
    }
}
