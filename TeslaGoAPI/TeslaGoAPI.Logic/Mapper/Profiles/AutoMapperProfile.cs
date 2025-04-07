using AutoMapper;
using TeslaGoAPI.DB.Entities;
using TeslaGoAPI.Logic.Dto.RequestDto;
using TeslaGoAPI.Logic.Dto.ResponseDto;
using TeslaGoAPI.Logic.Identity.Dto.RequestDto;

namespace TeslaGoAPI.Logic.Mapper.Profiles
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            // Address
            CreateMap<Address, Address>();
            CreateMap<AddressRequestDto, Address>();
            CreateMap<Address, AddressResponseDto>();

            // BodyType
            CreateMap<BodyType, BodyType>();
            CreateMap<BodyTypeRequestDto, BodyType>();
            CreateMap<BodyType, BodyTypeResponseDto>();

            // Brand
            CreateMap<Brand, Brand>();
            CreateMap<BrandRequestDto, Brand>();
            CreateMap<Brand, BrandResponseDto>();

            // CarModelDetails
            CreateMap<CarModelDetails, CarModelDetails>();
            CreateMap<CarModelDetailsRequestDto, CarModelDetails>();
            CreateMap<CarModelDetails, CarModelDetailsResponseDto>();

            // CarModel
            CreateMap<CarModel, CarModel>();
            CreateMap<CarModelRequestDto, CarModel>();
            CreateMap<CarModel, CarModelResponseDto>();

            // Car
            CreateMap<Car, Car>();
            CreateMap<CarRequestDto, Car>();
            CreateMap<Car, CarResponseDto>();

            // City
            CreateMap<City, City>();
            CreateMap<CityRequestDto, City>();
            CreateMap<City, CityResponseDto>();

            // Country
            CreateMap<Country, Country>();
            CreateMap<CountryRequestDto, Country>();
            CreateMap<Country, CountryResponseDto>();

            // DriveType
            CreateMap<DB.Entities.DriveType, DB.Entities.DriveType>();
            CreateMap<DriveTypeRequestDto, DB.Entities.DriveType>();
            CreateMap<DB.Entities.DriveType, DriveTypeResponseDto>();

            // Equipment
            CreateMap<Equipment, Equipment>();
            CreateMap<EquipmentRequestDto, Equipment>();
            CreateMap<Equipment, EquipmentResponseDto>();

            // FuelType
            CreateMap<FuelType, FuelType>();
            CreateMap<FuelTypeRequestDto, FuelType>();
            CreateMap<FuelType, FuelTypeResponseDto>();

            // GearBox
            CreateMap<GearBox, GearBox>();
            CreateMap<GearBoxRequestDto, GearBox>();
            CreateMap<GearBox, GearBoxResponseDto>();

            // Location
            CreateMap<Location, Location>();
            CreateMap<LocationRequestDto, Location>();
            CreateMap<Location, LocationResponseDto>();

            // ModelVersion
            CreateMap<ModelVersion, ModelVersion>();
            CreateMap<ModelVersionRequestDto, ModelVersion>();
            CreateMap<ModelVersion, ModelVersionResponseDto>();

            // OptService
            CreateMap<OptService, OptService>();
            CreateMap<OptServiceRequestDto, OptService>();
            CreateMap<OptService, OptServiceResponseDto>();

            // Paint
            CreateMap<Paint, Paint>();
            CreateMap<PaintRequestDto, Paint>();
            CreateMap<Paint, PaintResponseDto>();

            // PaymentMethod
            CreateMap<PaymentMethod, PaymentMethod>();
            CreateMap<PaymentMethodRequestDto, PaymentMethod>();
            CreateMap<PaymentMethod, PaymentMethodResponseDto>();

            // Reservation
            CreateMap<Reservation, Reservation>();
            CreateMap<ReservationRequestDto, Reservation>();
            CreateMap<Reservation, ReservationResponseDto>();

            // CarAvailabilityIssueResponseDto
            CreateMap<CarAvailabilityIssue, CarAvailabilityIssueResponseDto>();

            // User
            CreateMap<User, User>();
            CreateMap<UserRegisterRequestDto, User>()
                .ForMember(u => u.UserName, opt => opt.MapFrom(dto => dto.Email));
            CreateMap<User, UserResponseDto>();
        }
    }
}
