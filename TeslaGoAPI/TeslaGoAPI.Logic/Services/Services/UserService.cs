
using Serilog;
using System.IO;
using System.Reflection.Emit;
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
    public sealed class UserService(IUnitOfWork unitOfWork, IAuthService authService, IAddressService addressService)
           : GenericService<
               User,
               UserRequestDto,
               UserRequestDto,
               UserResponseDto,
               UserQuery>(unitOfWork, authService), IUserService
    {
        private readonly IAddressService _addressService = addressService;
        public async Task<Result<object>> SetUserInfo(UserDataRequestDto userDataRequestDto)
        {
            var userResult = await _authService.GetCurrentUserAsEntity();
            if (!userResult.IsSuccessful)
                return Result<object>.Failure(userResult.Error);
            var user = userResult.Value;

            Log.Information("user {@user}",user.Email);

            user.DrivingLicenseNumber = userDataRequestDto.DrivingLicenseNumber;
            if(user.Address == null)
            {
                var address = new Address
                {
                    Street = userDataRequestDto.Street,
                    HouseNr = userDataRequestDto.HouseNumber,
                    FlatNr = userDataRequestDto.FlatNumber,
                    ZipCode = userDataRequestDto.ZipCode,
                };
                await _addressService.AddCityToAddress(address, userDataRequestDto.City, userDataRequestDto.CountryId);
            }
            else
            {
                user.Address.Street = userDataRequestDto.Street;
                user.Address.HouseNr = userDataRequestDto.HouseNumber;
                user.Address.FlatNr = userDataRequestDto.FlatNumber;
                user.Address.ZipCode = userDataRequestDto.ZipCode;
                await _addressService.AddCityToAddress(user.Address, userDataRequestDto.City, userDataRequestDto.CountryId);
            }


            _unitOfWork.GetRepository<User>().Update(user);
            await _unitOfWork.SaveChangesAsync();

            return Result<object>.Success();
        }
    }
}
