using TeslaGoAPI.Logic.Dto.RequestDto;
using TeslaGoAPI.Logic.Dto.ResponseDto;
using TeslaGoAPI.Logic.Query;
using TeslaGoAPI.Logic.Services.Interfaces.Abstract;

namespace TeslaGoAPI.Logic.Services.Interfaces
{
    public interface IDriveTypeService : IGenericService<DB.Entities.DriveType, DriveTypeRequestDto, DriveTypeResponseDto, DriveTypeQuery>
    {
    }
}
