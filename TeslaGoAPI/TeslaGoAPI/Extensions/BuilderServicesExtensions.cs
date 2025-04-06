using TeslaGoAPI.Logic.Identity.Services.Interfaces;
using TeslaGoAPI.Logic.Identity.Services.Services;
using TeslaGoAPI.Logic.Services.Interfaces;
using TeslaGoAPI.Logic.Services.Services;
using TeslaGoAPI.Logic.UnitOfWork;

namespace TeslaGoAPI.Extensions
{
    public static class BuilderServicesExtensions
    {
        public static void AddUnitOfWork(this IServiceCollection services)
        {
            services.AddTransient<IUnitOfWork, UnitOfWork>();
        }

        public static void AddCRUDServices(this IServiceCollection services)
        {
            services.AddScoped<IAddressService, AddressService>();
            services.AddScoped<IBodyTypeService, BodyTypeService>();
            services.AddScoped<IBrandService, BrandService>();
            services.AddScoped<ICarModelService, CarModelService>();
            services.AddScoped<ICarService, CarService>();
            services.AddScoped<ICityService, CityService>();
            services.AddScoped<ICountryService, CountryService>();
            services.AddScoped<IDriveTypeService, DriveTypeService>();
            services.AddScoped<IEquipmentService, EquipmentService>();
            services.AddScoped<IFuelTypeService, FuelTypeService>();
            services.AddScoped<IGearBoxService, GearBoxService>();
            services.AddScoped<ILocationService, LocationService>();
            services.AddScoped<IModelVersionService, ModelVersionService>();
            services.AddScoped<IOptServiceService, OptServiceService>();
            services.AddScoped<IPaintService, PaintService>();
            services.AddScoped<IPaymentMethodService, PaymentMethodService>();
            services.AddScoped<IReservationService, ReservationService>();
            services.AddScoped<IUserService, UserService>();
        }

        public static void AddApplicationAuthServices(this IServiceCollection services)
        {
            services.AddScoped<IAuthService, AuthService>();
            services.AddSingleton<IJWTGeneratorService, JWTGeneratorService>();
        }
    }
}
