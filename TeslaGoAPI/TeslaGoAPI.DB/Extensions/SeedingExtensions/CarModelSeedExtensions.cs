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
                    ImageName = "tesla_model_s.png",
                    DoorCount = 4,
                    HorsePower = 670,
                    AccelerationInSeconds = 3.2m,
                    MaxSpeedInKmPerHour = 250,
                    TrunkCapacityLiters = 793,
                    TrunkCapacitySuitCases = 6,
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
                    ImageName = "tesla_model_s.png",
                    DoorCount = 4,
                    HorsePower = 1020,
                    AccelerationInSeconds = 2.1m,
                    MaxSpeedInKmPerHour = 322,
                    TrunkCapacityLiters = 793,
                    TrunkCapacitySuitCases = 6,
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
                    ImageName = "tesla_model_3.png",
                    DoorCount = 4,
                    HorsePower = 283,
                    AccelerationInSeconds = 6.1m,
                    MaxSpeedInKmPerHour = 225,
                    TrunkCapacityLiters = 682,
                    TrunkCapacitySuitCases = 5,
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
                     ImageName = "tesla_model_3.png",
                     DoorCount = 4,
                     HorsePower = 283,
                     AccelerationInSeconds = 5.2m,
                     MaxSpeedInKmPerHour = 225,
                     TrunkCapacityLiters = 682,
                     TrunkCapacitySuitCases = 5,
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
                      ImageName = "tesla_model_3.png",
                      DoorCount = 4,
                      HorsePower = 346,
                      AccelerationInSeconds = 4.4m,
                      MaxSpeedInKmPerHour = 233,
                      TrunkCapacityLiters = 682,
                      TrunkCapacitySuitCases = 5,
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
                      ImageName = "tesla_model_3.png",
                      DoorCount = 4,
                      HorsePower = 472,
                      AccelerationInSeconds = 3.1m,
                      MaxSpeedInKmPerHour = 261,
                      TrunkCapacityLiters = 682,
                      TrunkCapacitySuitCases = 5,
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
                      ImageName = "tesla_model_y.png",
                      DoorCount = 4,
                      HorsePower = 283,
                      AccelerationInSeconds = 6.9m,
                      MaxSpeedInKmPerHour = 217,
                      TrunkCapacityLiters = 2158,
                      TrunkCapacitySuitCases = 12,
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
                     ImageName = "tesla_model_y.png",
                     DoorCount = 4,
                     HorsePower = 283,
                     AccelerationInSeconds = 5.9m,
                     MaxSpeedInKmPerHour = 217,
                     TrunkCapacityLiters = 2158,
                     TrunkCapacitySuitCases = 12,
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
                      ImageName = "tesla_model_y.png",
                      DoorCount = 4,
                      HorsePower = 351,
                      AccelerationInSeconds = 5.0m,
                      MaxSpeedInKmPerHour = 217,
                      TrunkCapacityLiters = 2158,
                      TrunkCapacitySuitCases = 12,
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
                      ImageName = "tesla_model_y.png",
                      DoorCount = 4,
                      HorsePower = 456,
                      AccelerationInSeconds = 3.7m,
                      MaxSpeedInKmPerHour = 250,
                      TrunkCapacityLiters = 2158,
                      TrunkCapacitySuitCases = 12,
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
                      ImageName = "tesla_model_x.png",
                      DoorCount = 4,
                      HorsePower = 670,
                      AccelerationInSeconds = 3.9m,
                      MaxSpeedInKmPerHour = 250,
                      TrunkCapacityLiters = 2614,
                      TrunkCapacitySuitCases = 14,
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
                      ImageName = "tesla_model_x.png",
                      DoorCount = 4,
                      HorsePower = 1020,
                      AccelerationInSeconds = 2.6m,
                      MaxSpeedInKmPerHour = 262,
                      TrunkCapacityLiters = 2614,
                      TrunkCapacitySuitCases = 14,
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
                      ImageName = "tesla_cybertruck.png",
                      DoorCount = 4,
                      HorsePower = 315,
                      AccelerationInSeconds = 6.7m,
                      MaxSpeedInKmPerHour = 180,
                      TrunkCapacityLiters = 2830,
                      TrunkCapacitySuitCases = 16,

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
                      ImageName = "tesla_cybertruck.png",
                      DoorCount = 4,
                      HorsePower = 600,
                      AccelerationInSeconds = 4.3m,
                      MaxSpeedInKmPerHour = 180,
                      TrunkCapacityLiters = 2830,
                      TrunkCapacitySuitCases = 16,
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
                       ImageName = "tesla_cybertruck.png",
                       DoorCount = 4,
                       HorsePower = 845,
                       AccelerationInSeconds = 2.7m,
                       MaxSpeedInKmPerHour = 209,
                       TrunkCapacityLiters = 2830,
                       TrunkCapacitySuitCases = 16,
                   }
            );
                   
        }
    }
}
