using TeslaGoAPI.DB.Entities;
using TeslaGoAPI.Logic.Dto.RequestDto;
using TeslaGoAPI.Logic.Dto.ResponseDto;
using TeslaGoAPI.Logic.Identity.Services.Interfaces;
using TeslaGoAPI.Logic.Query;
using TeslaGoAPI.Logic.Services.Interfaces;
using TeslaGoAPI.Logic.Services.Services.Abstract;
using TeslaGoAPI.Logic.UnitOfWork;

namespace TeslaGoAPI.Logic.Services.Services
{
    public sealed class EquipmentService(IUnitOfWork unitOfWork, IAuthService authService)
       : GenericService<
           Equipment,
           EquipmentRequestDto,
           EquipmentResponseDto,
           EquipmentQuery>(unitOfWork, authService), IEquipmentService
    {
    }
}
