using TeslaGoAPI.DB.Entities;
using TeslaGoAPI.Logic.Dto.ResponseDto;
using TeslaGoAPI.Logic.Errors;
using TeslaGoAPI.Logic.Mapper.Extensions;
using TeslaGoAPI.Logic.Repositories.Interfaces.Abstract;
using TeslaGoAPI.Logic.Result;
using TeslaGoAPI.Logic.Services.Interfaces;
using TeslaGoAPI.Logic.UnitOfWork;

namespace TeslaGoAPI.Logic.Services.Services
{
    public class CarAvailabilityIssueService(IUnitOfWork unitOfWork) : ICarAvailabilityIssueService
    {
        private IGenericRepository<CarAvailabilityIssue> _repository = unitOfWork.GetRepository<CarAvailabilityIssue>();
        public async Task<IEnumerable<CarAvailabilityIssueResponseDto>> GetAllAsync()
        {
            var records = await _repository.GetAllAsync();
            var response = MapAsDto(records);
            return response;
        }

        public async Task<Result<CarAvailabilityIssueResponseDto>> GetOneAsync(int id)
        {
            if (id < 0)
                return Result<CarAvailabilityIssueResponseDto>.Failure(Error.RouteParamOutOfRange);

            var record = await _repository.GetOneAsync(id);
            if (record == null)
                return Result<CarAvailabilityIssueResponseDto>.Failure(Error.NotFound);

            var response = MapAsDto(record);

            return Result<CarAvailabilityIssueResponseDto>.Success(response);
        }

        public virtual async Task<Result<object>> DeleteAsync(int id)
        {
            if (id < 0)
                return Result<object>.Failure(Error.RouteParamOutOfRange);

            var entity = await _repository.GetOneAsync(id);
            if (entity == null)
                return Result<object>.Failure(Error.NotFound);

            _repository.Delete(entity);
            await unitOfWork.SaveChangesAsync();

            return Result<object>.Success();
        }

        private IEnumerable<CarAvailabilityIssueResponseDto> MapAsDto(IEnumerable<CarAvailabilityIssue> records)
        {
            return records.Select(entity => MapAsDto(entity));
        }

        private CarAvailabilityIssueResponseDto MapAsDto(CarAvailabilityIssue entity)
        {
            var responseDto = entity.AsDto<CarAvailabilityIssueResponseDto>();
            responseDto.Reservation = entity.Reservation.AsDto<ReservationResponseDto>();
            responseDto.Reservation.User = entity.Reservation.User.AsDto<UserResponseDto>();
            responseDto.CarModel = entity.CarModel.AsDto<CarModelResponseDto>();
            responseDto.CarModel.Brand = entity.CarModel.Brand.AsDto<BrandResponseDto>();
            responseDto.CarModel.ModelVersion = entity.CarModel.ModelVersion.AsDto<ModelVersionResponseDto>();
            responseDto.CarModel.DriveType = entity.CarModel.DriveType.AsDto<DriveTypeResponseDto>();
            responseDto.Location = entity.Location.AsDto<LocationResponseDto>();

            return responseDto;
        }
    }
}
