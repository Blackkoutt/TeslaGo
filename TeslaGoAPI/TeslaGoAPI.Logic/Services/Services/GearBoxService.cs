using TeslaGoAPI.DB.Entities;
using TeslaGoAPI.Logic.Dto.RequestDto;
using TeslaGoAPI.Logic.Dto.ResponseDto;
using TeslaGoAPI.Logic.Identity.Services.Interfaces;
using TeslaGoAPI.Logic.Query;
using TeslaGoAPI.Logic.Result;
using TeslaGoAPI.Logic.Services.Interfaces;
using TeslaGoAPI.Logic.Services.Services.Abstract;
using TeslaGoAPI.Logic.UnitOfWork;

namespace TeslaGoAPI.Logic.Services.Services
{
    public sealed class GearBoxService(IUnitOfWork unitOfWork, IAuthService authService)
        : GenericService<
            GearBox,
            GearBoxRequestDto,
            GearBoxRequestDto,
            GearBoxResponseDto,
            GearBoxQuery>(unitOfWork, authService), IGearBoxService
    {
        public sealed override async Task<Result<object>> DeleteAsync(int id)
        {
            var validationResult = await ValidateBeforeDelete(id);
            if (!validationResult.IsSuccessful)
                return Result<object>.Failure(validationResult.Error);

            var entity = validationResult.Value;

            entity.DeleteDate = DateTime.Now;
            entity.IsDeleted = true;

            var carsRepository = _unitOfWork.GetRepository<Car>();
            var carsToDelete = await carsRepository.GetAllAsync(q => q.Where(x => x.Model.GearBoxId == id));

            base.DeleteCarsAndReservations(carsRepository, carsToDelete);

            _repository.Update(entity);

            await _unitOfWork.SaveChangesAsync();

            return Result<object>.Success();
        }
    }
}
