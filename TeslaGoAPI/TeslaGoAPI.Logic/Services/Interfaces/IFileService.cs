using TeslaGoAPI.Logic.Helpers;
using TeslaGoAPI.Logic.Result;

namespace TeslaGoAPI.Logic.Services.Interfaces
{
    public interface IFileService
    {
        Task<Result<BlobResponseDto>> GetCarModelImage(int? id);
    }
}
