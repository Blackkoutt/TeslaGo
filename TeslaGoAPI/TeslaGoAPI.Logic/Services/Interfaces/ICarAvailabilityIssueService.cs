using TeslaGoAPI.Logic.Dto.ResponseDto;
using TeslaGoAPI.Logic.Repositories.Interfaces.Abstract;
using TeslaGoAPI.Logic.Result;

namespace TeslaGoAPI.Logic.Services.Interfaces
{
    public interface ICarAvailabilityIssueService
    {
        Task<IEnumerable<CarAvailabilityIssueResponseDto>> GetAllAsync();
        Task<Result<CarAvailabilityIssueResponseDto>> GetOneAsync(int id);
        Task<Result<object>> DeleteAsync(int id);
    }
}
