using TeslaGoAPI.DB.Entities;
using TeslaGoAPI.Logic.Dto.ResponseDto;
using TeslaGoAPI.Logic.Errors;
using TeslaGoAPI.Logic.Extensions;
using TeslaGoAPI.Logic.Identity.Enums;
using TeslaGoAPI.Logic.Identity.Services.Interfaces;
using TeslaGoAPI.Logic.Mapper.Extensions;
using TeslaGoAPI.Logic.Repositories.Interfaces.Abstract;
using TeslaGoAPI.Logic.Result;
using TeslaGoAPI.Logic.Services.Interfaces;
using TeslaGoAPI.Logic.UnitOfWork;

namespace TeslaGoAPI.Logic.Services.Services
{
    public class CarAvailabilityIssueService(IUnitOfWork unitOfWork, IAuthService authService) : ICarAvailabilityIssueService
    {
        private readonly IGenericRepository<CarAvailabilityIssue> _repository = unitOfWork.GetRepository<CarAvailabilityIssue>();
        private readonly IAuthService _authService = authService;
        public async Task<Result<IEnumerable<CarAvailabilityIssueResponseDto>>> GetAllAsync()
        {
            var userError = await IsUserInAdminRole();
            if(userError != Error.None)
                return Result<IEnumerable<CarAvailabilityIssueResponseDto>>.Failure(userError);    

            var records = await _repository.GetAllAsync();
            var response = MapAsDto(records);

            return Result<IEnumerable<CarAvailabilityIssueResponseDto>>.Success(response);
        }


        public async Task<Result<CarAvailabilityIssueResponseDto>> GetOneAsync(int id)
        {
            if (id < 0)
                return Result<CarAvailabilityIssueResponseDto>.Failure(Error.RouteParamOutOfRange);

            var userError = await IsUserInAdminRole();
            if (userError != Error.None)
                return Result<CarAvailabilityIssueResponseDto>.Failure(userError);

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

            var userError = await IsUserInAdminRole();
            if (userError != Error.None)
                return Result<object>.Failure(userError);

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

        private async Task<Error> IsUserInAdminRole()
        {
            var userResult = await _authService.GetCurrentUserAsEntity();
            if (!userResult.IsSuccessful)
                return userResult.Error;

            var user = userResult.Value;

            if (!user.IsInRole(Roles.Admin))
                return AuthError.UserDoesNotHavePremissionToResource;

            return Error.None;
        }
    }
}
