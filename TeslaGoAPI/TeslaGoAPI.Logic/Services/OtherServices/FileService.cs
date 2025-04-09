using Microsoft.Extensions.Options;
using TeslaGoAPI.DB.Entities;
using TeslaGoAPI.Logic.Errors;
using TeslaGoAPI.Logic.Helpers;
using TeslaGoAPI.Logic.Result;
using TeslaGoAPI.Logic.Services.Interfaces;
using TeslaGoAPI.Logic.Settings;
using TeslaGoAPI.Logic.UnitOfWork;

namespace TeslaGoAPI.Logic.Services.OtherServices
{
    public class FileService(IUnitOfWork unitOfWork, IOptions<CarModelImageSettings> settings) : IFileService
    {
        private readonly IUnitOfWork _unitOfWork = unitOfWork;
        private readonly IOptions<CarModelImageSettings> _settings = settings;
        public async Task<Result<BlobResponseDto>> GetCarModelImage(int? id)
        {
            var validationResult = await ValidateCarModel(id);
            if (!validationResult.IsSuccessful)
                return Result<BlobResponseDto>.Failure(validationResult.Error);

            var imageName = validationResult.Value.ImageName;
            if (string.IsNullOrEmpty(imageName))
                imageName = _settings.Value.DefaultImageName;

            var contentType = GetContentType(imageName);

            var bitmapResult = await GetFileAsBitmap(imageName);
            if (!bitmapResult.IsSuccessful)
                return Result<BlobResponseDto>.Failure(bitmapResult.Error);

            var imageBitmap = bitmapResult.Value;

            using (var memoryStream = new MemoryStream(imageBitmap))
            {
                var imageData = memoryStream.ToArray();

                var blobResponse = new BlobResponseDto
                {
                    FileName = imageName,
                    Data = imageData,
                    ContentType = contentType,
                };

                return Result<BlobResponseDto>.Success(blobResponse);
            }

        }

        private async Task<Result<CarModel>> ValidateCarModel(int? id)
        {
            if (id == null || id < 0)
                return Result<CarModel>.Failure(Error.RouteParamOutOfRange);

            var model = await _unitOfWork.GetRepository<CarModel>().GetOneAsync((int)id);
            if (model == null)
                return Result<CarModel>.Failure(CarModelError.NotFound);

            return Result<CarModel>.Success(model);
        }

        private async Task<Result<byte[]>> GetFileAsBitmap(string imageName)
        {
            var workingDirectory = Directory.GetCurrentDirectory();
            var imagePath = Path.Combine(workingDirectory, _settings.Value.PathToCarModelImages, imageName);

            if (!File.Exists(imagePath))
                return Result<byte[]>.Failure(Error.ImageNotFound);

            var imageByte = await File.ReadAllBytesAsync(imagePath);

            return Result<byte[]>.Success(imageByte);
        }

        public string GetContentType(string imageName)
        {
            var fileExtension = Path.GetExtension(imageName);

            var extension = fileExtension.ToLowerInvariant();

            return extension switch
            {
                ".jpg" or ".jpeg" => "image/jpeg",
                ".png" => "image/png",  
                _ => "application/octet-stream", 
            };
        }
    }
}
