using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TeslaGoAPI.DB.Entities;

namespace TeslaGoAPI.DB.Extensions.SeedingExtensions
{
    public static class CarModelSeedExtensions
    {
        public static void Seed(this EntityTypeBuilder<CarModel> entityBuilder)
        {
            entityBuilder.HasData(

                // Model S Standard RWD
                new CarModel
                {
                    Id = 1,
                    Name = "Model S",
                    SeatCount = 5,
                    PricePerDay = 100m,
                    Range = 634,
                    BrandId = 1, // Tesla
                    GearBoxId = 1, // Single-Speed
                    FuelTypeId = 1, // Electric
                    BodyTypeId = 1, // Sedan
                    ModelVersionId = 1, // Standard
                    DriveTypeId = 1, // RWD
                },

                // Model S Plaid RWD
                new CarModel
                {
                    Id = 2,
                    Name = "Model S",
                    SeatCount = 5,
                    PricePerDay = 170m,
                    Range = 600,
                    BrandId = 1, // Tesla
                    GearBoxId = 1, // Single-Speed
                    FuelTypeId = 1, // Electric
                    BodyTypeId = 1, // Sedan
                    ModelVersionId = 4, // Plaid
                    DriveTypeId = 1, // RWD
                },

                // Model 3 Standard RWD
                new CarModel
                {
                    Id = 3,
                    Name = "Model 3",
                    SeatCount = 5,
                    PricePerDay = 80m,
                    Range = 513,
                    BrandId = 1, // Tesla
                    GearBoxId = 1, // Single-Speed
                    FuelTypeId = 1, // Electric
                    BodyTypeId = 1, // Sedan
                    ModelVersionId = 1, // Standard
                    DriveTypeId = 1, // RWD
                },

                 // Model 3 Long Range RWD
                 new CarModel
                 {
                     Id = 4,
                     Name = "Model 3",
                     SeatCount = 5,
                     PricePerDay = 100m,
                     Range = 702,
                     BrandId = 1, // Tesla
                     GearBoxId = 1, // Single-Speed
                     FuelTypeId = 1, // Electric
                     BodyTypeId = 1, // Sedan
                     ModelVersionId = 2, // Long Range
                     DriveTypeId = 1, // RWD
                 },

                  // Model 3 Long Range AWD
                  new CarModel
                  {
                      Id = 5,
                      Name = "Model 3",
                      SeatCount = 5,
                      PricePerDay = 110m,
                      Range = 629,
                      BrandId = 1, // Tesla
                      GearBoxId = 1, // Single-Speed
                      FuelTypeId = 1, // Electric
                      BodyTypeId = 1, // Sedan
                      ModelVersionId = 2, // Long Range
                      DriveTypeId = 2, // AWD
                  },

                  // Model 3 Performance AWD
                  new CarModel
                  {
                      Id = 6,
                      Name = "Model 3",
                      SeatCount = 5,
                      PricePerDay = 140m,
                      Range = 528,
                      BrandId = 1, // Tesla
                      GearBoxId = 1, // Single-Speed
                      FuelTypeId = 1, // Electric
                      BodyTypeId = 1, // Sedan
                      ModelVersionId = 3, // Performance
                      DriveTypeId = 2, // AWD
                  },

                  // Model Y Standard RWD
                  new CarModel
                  {
                      Id = 7,
                      Name = "Model Y",
                      SeatCount = 5,
                      PricePerDay = 60m,
                      Range = 455,
                      BrandId = 1, // Tesla
                      GearBoxId = 1, // Single-Speed
                      FuelTypeId = 1, // Electric
                      BodyTypeId = 2, // SUV
                      ModelVersionId = 1, // Standard
                      DriveTypeId = 1, // RWD
                  },

                 // Model Y Long Range RWD
                 new CarModel
                 {
                     Id = 8,
                     Name = "Model Y",
                     SeatCount = 5,
                     PricePerDay = 75m,
                     Range = 600,
                     BrandId = 1, // Tesla
                     GearBoxId = 1, // Single-Speed
                     FuelTypeId = 1, // Electric
                     BodyTypeId = 2, // SUV
                     ModelVersionId = 2, // Long Range
                     DriveTypeId = 1, // RWD
                 },

                  // Model Y Long Range AWD
                  new CarModel
                  {
                      Id = 9,
                      Name = "Model Y",
                      SeatCount = 5,
                      PricePerDay = 85m,
                      Range = 533,
                      BrandId = 1, // Tesla
                      GearBoxId = 1, // Single-Speed
                      FuelTypeId = 1, // Electric
                      BodyTypeId = 2, // SUV
                      ModelVersionId = 2, // Long Range
                      DriveTypeId = 2, // AWD
                  },

                  // Model Y Performance AWD
                  new CarModel
                  {
                      Id = 10,
                      Name = "Model Y",
                      SeatCount = 5,
                      PricePerDay = 115m,
                      Range = 514,
                      BrandId = 1, // Tesla
                      GearBoxId = 1, // Single-Speed
                      FuelTypeId = 1, // Electric
                      BodyTypeId = 2, // SUV
                      ModelVersionId = 3, // Performance
                      DriveTypeId = 2, // AWD
                  },

                  // Model X Standard AWD
                  new CarModel
                  {
                      Id = 11,
                      Name = "Model X",
                      SeatCount = 5,
                      PricePerDay = 105m,
                      Range = 576,
                      BrandId = 1, // Tesla
                      GearBoxId = 1, // Single-Speed
                      FuelTypeId = 1, // Electric
                      BodyTypeId = 2, // SUV
                      ModelVersionId = 1, // Standard
                      DriveTypeId = 2, // AWD
                  },

                  // Model X Plaid AWD
                  new CarModel
                  {
                      Id = 12,
                      Name = "Model X",
                      SeatCount = 5,
                      PricePerDay = 145m,
                      Range = 543,
                      BrandId = 1, // Tesla
                      GearBoxId = 1, // Single-Speed
                      FuelTypeId = 1, // Electric
                      BodyTypeId = 2, // SUV
                      ModelVersionId = 4, // Plaid
                      DriveTypeId = 2, // AWD              
                  },

                  // Cybertruck Standard RWD
                  new CarModel
                  {
                      Id = 13,
                      Name = "Cybertruck",
                      SeatCount = 5,
                      PricePerDay = 140m,
                      Range = 402,
                      BrandId = 1, // Tesla
                      GearBoxId = 1, // Single-Speed
                      FuelTypeId = 1, // Electric
                      BodyTypeId = 3, // Pickup
                      ModelVersionId = 1, // Standard
                      DriveTypeId = 1, // RWD
                  },

                  // Cybertruck Standard AWD
                  new CarModel
                  {
                      Id = 14,
                      Name = "Cybertruck",
                      SeatCount = 5,
                      PricePerDay = 170m,
                      Range = 547,
                      BrandId = 1, // Tesla
                      GearBoxId = 1, // Single-Speed
                      FuelTypeId = 1, // Electric
                      BodyTypeId = 3, // Pickup
                      ModelVersionId = 1, // Standard
                      DriveTypeId = 2, // AWD
                  },

                   // Cybertruck Cyber-beast RWD
                   new CarModel
                   {
                       Id = 15,
                       Name = "Cybertruck",
                       SeatCount = 5,
                       PricePerDay = 210m,
                       Range = 515,
                       BrandId = 1, // Tesla
                       GearBoxId = 1, // Single-Speed
                       FuelTypeId = 1, // Electric
                       BodyTypeId = 3, // Pickup
                       ModelVersionId = 5, // Cyber-beast
                       DriveTypeId = 2, // AWD
                   }
            );
                   
        }
    }
}
