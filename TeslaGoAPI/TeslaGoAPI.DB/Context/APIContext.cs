using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TeslaGoAPI.DB.Entities;
using TeslaGoAPI.DB.Extensions;

namespace TeslaGoAPI.DB.Context
{
    public class APIContext(DbContextOptions<APIContext> options) : IdentityDbContext<User, Role, int>(options)
    {
        public DbSet<Address> Address { get; set; }
        public DbSet<City> City { get; set; }
        public DbSet<Country> Country { get; set; }
        public DbSet<BodyType> BodyType { get; set; }
        public DbSet<Brand> Brand { get; set; }
        public DbSet<Car> Car { get; set; }
        public DbSet<Entities.DriveType> DriveType { get; set; }
        public DbSet<Equipment> Equipment { get; set; }
        public DbSet<FuelType> FuelType { get; set; }
        public DbSet<GearBox> GearBox { get; set; }
        public DbSet<Location> Location { get; set; }
        public DbSet<CarModel> CarModel { get; set; }
        public DbSet<CarModelDetails> CarModelDetails { get; set; }
        public DbSet<OptService> OptService { get; set; }
        public DbSet<Paint> Paint { get; set; }
        public DbSet<PaymentMethod> PaymentMethod { get; set; }
        public DbSet<Reservation> Reservation { get; set; }
        public DbSet<ModelVersion> ModelVersion { get; set; }
        public DbSet<CarModel_Equipment> CarModel_Equipment { get; set; }
        public DbSet<Reservation_OptService> Reservation_OptService { get; set; }
        public DbSet<Car_Location> Car_Location { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ConfigureEntityRelations();
            builder.AddEntitiesConstraints();
            builder.AddEntitiesIndexes();
            builder.Seed();
        }

    }
}
