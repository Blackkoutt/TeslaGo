using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TeslaGoAPI.DB.Entities;

namespace TeslaGoAPI.DB.Extensions.SeedingExtensions
{
    public static class CarModel_EquipmentSeedExtensions
    {
        public static void Seed(this EntityTypeBuilder<CarModel_Equipment> entityBuilder)
        {
            entityBuilder.HasData(

                // Model S Standard RWD
                new CarModel_Equipment
                {
                    CarModelId = 1,
                    EquipmentId = 1, // Autopilot
                },
                new CarModel_Equipment
                {
                    CarModelId = 1,
                    EquipmentId = 2, // Full Self-Driving (FSD) Package
                },
                new CarModel_Equipment
                {
                    CarModelId = 1,
                    EquipmentId = 4, // Heated Seats
                },
                new CarModel_Equipment
                {
                    CarModelId = 1,
                    EquipmentId = 9, // 19\" Wheels
                },



                // Model S Plaid RWD
                new CarModel_Equipment
                {
                    CarModelId = 2,
                    EquipmentId = 1, // Autopilot
                },
                new CarModel_Equipment
                {
                    CarModelId = 2,
                    EquipmentId = 2, // Full Self-Driving (FSD) Package
                },
                new CarModel_Equipment
                {
                    CarModelId = 2,
                    EquipmentId = 3, // Premium Interior
                },
                new CarModel_Equipment
                {
                    CarModelId = 2,
                    EquipmentId = 4, // Heated Seats
                },
                new CarModel_Equipment
                {
                    CarModelId = 2,
                    EquipmentId = 6, // Supercharging
                },
                new CarModel_Equipment
                {
                    CarModelId = 2,
                    EquipmentId = 11, // 20\" Sport Wheels
                },

                // Model 3 Standard RWD
                new CarModel_Equipment
                {
                    CarModelId = 3,
                    EquipmentId = 1, // Autopilot
                },
                new CarModel_Equipment
                {
                    CarModelId = 3,
                    EquipmentId = 2, // Full Self-Driving (FSD) Package
                },
                new CarModel_Equipment
                {
                    CarModelId = 3,
                    EquipmentId = 4, // Heated Seats
                },
                new CarModel_Equipment
                {
                    CarModelId = 3,
                    EquipmentId = 9, // 19\" Wheels
                },


                // Model 3 Long Range RWD
                new CarModel_Equipment
                {
                    CarModelId = 4,
                    EquipmentId = 1, // Autopilot
                },
                new CarModel_Equipment
                {
                    CarModelId = 4,
                    EquipmentId = 2, // Full Self-Driving (FSD) Package
                },
                new CarModel_Equipment
                {
                    CarModelId = 4,
                    EquipmentId = 4, // Heated Seats
                },
                new CarModel_Equipment
                {
                    CarModelId = 4,
                    EquipmentId = 9, // 19\" Wheels
                },



                // Model 3 Long Range AWD
                new CarModel_Equipment
                {
                    CarModelId = 5,
                    EquipmentId = 1, // Autopilot
                },
                new CarModel_Equipment
                {
                    CarModelId = 5,
                    EquipmentId = 2, // Full Self-Driving (FSD) Package
                },
                new CarModel_Equipment
                {
                    CarModelId = 5,
                    EquipmentId = 4, // Heated Seats
                },
                new CarModel_Equipment
                {
                    CarModelId = 5,
                    EquipmentId = 9, // 19\" Wheels
                },


                 // Model 3 Performance AWD
                 new CarModel_Equipment
                 {
                     CarModelId = 6,
                     EquipmentId = 1, // Autopilot
                 },
                new CarModel_Equipment
                {
                    CarModelId = 6,
                    EquipmentId = 2, // Full Self-Driving (FSD) Package
                },
                new CarModel_Equipment
                {
                    CarModelId = 6,
                    EquipmentId = 4, // Heated Seats
                },
                new CarModel_Equipment
                {
                    CarModelId = 6,
                    EquipmentId = 6, // Supercharging
                },
                new CarModel_Equipment
                {
                    CarModelId = 6,
                    EquipmentId = 11, // 20\" Sport Wheels
                },


                // Model Y Standard RWD
                new CarModel_Equipment
                {
                    CarModelId = 7,
                    EquipmentId = 1, // Autopilot
                },
                new CarModel_Equipment
                {
                    CarModelId = 7,
                    EquipmentId = 2, // Full Self-Driving (FSD) Package
                },
                new CarModel_Equipment
                {
                    CarModelId = 7,
                    EquipmentId = 4, // Heated Seats
                },
                new CarModel_Equipment
                {
                    CarModelId = 7,
                    EquipmentId = 9, // 19\" Wheels
                },

                // Model Y Long Range RWD
                new CarModel_Equipment
                {
                    CarModelId = 8,
                    EquipmentId = 1, // Autopilot
                },
                new CarModel_Equipment
                {
                    CarModelId = 8,
                    EquipmentId = 2, // Full Self-Driving (FSD) Package
                },
                new CarModel_Equipment
                {
                    CarModelId = 8,
                    EquipmentId = 4, // Heated Seats
                },
                new CarModel_Equipment
                {
                    CarModelId = 8,
                    EquipmentId = 9, // 19\" Wheels
                },


                // Model Y Long Range AWD
                new CarModel_Equipment
                {
                    CarModelId = 9,
                    EquipmentId = 1, // Autopilot
                },
                new CarModel_Equipment
                {
                    CarModelId = 9,
                    EquipmentId = 2, // Full Self-Driving (FSD) Package
                },
                new CarModel_Equipment
                {
                    CarModelId = 9,
                    EquipmentId = 4, // Heated Seats
                },
                new CarModel_Equipment
                {
                    CarModelId = 9,
                    EquipmentId = 9, // 19\" Wheels
                },


                  // Model Y Performance AWD
                  new CarModel_Equipment
                  {
                      CarModelId = 10,
                      EquipmentId = 1, // Autopilot
                  },
                new CarModel_Equipment
                {
                    CarModelId = 10,
                    EquipmentId = 2, // Full Self-Driving (FSD) Package
                },
                new CarModel_Equipment
                {
                    CarModelId = 10,
                    EquipmentId = 4, // Heated Seats
                },
                new CarModel_Equipment
                {
                    CarModelId = 10,
                    EquipmentId = 6, // Supercharging
                },
                new CarModel_Equipment
                {
                    CarModelId = 10,
                    EquipmentId = 11, // 20\" Sport Wheels
                },


                // Model X Standard AWD
                new CarModel_Equipment
                {
                    CarModelId = 11,
                    EquipmentId = 1, // Autopilot
                },
                new CarModel_Equipment
                {
                    CarModelId = 11,
                    EquipmentId = 2, // Full Self-Driving (FSD) Package
                },
                new CarModel_Equipment
                {
                    CarModelId = 11,
                    EquipmentId = 4, // Heated Seats
                },
                new CarModel_Equipment
                {
                    CarModelId = 11,
                    EquipmentId = 9, // 19\" Wheels
                },


                // Model X Plaid AWD
                new CarModel_Equipment
                {
                    CarModelId = 12,
                    EquipmentId = 1, // Autopilot
                },
                new CarModel_Equipment
                {
                    CarModelId = 12,
                    EquipmentId = 2, // Full Self-Driving (FSD) Package
                },
                new CarModel_Equipment
                {
                    CarModelId = 12,
                    EquipmentId = 3, // Premium Interior
                },
                new CarModel_Equipment
                {
                    CarModelId = 12,
                    EquipmentId = 4, // Heated Seats
                },
                new CarModel_Equipment
                {
                    CarModelId = 12,
                    EquipmentId = 6, // Supercharging
                },
                new CarModel_Equipment
                {
                    CarModelId = 12,
                    EquipmentId = 11, // 20\" Sport Wheels
                },


                // Cybertruck Standard RWD
                new CarModel_Equipment
                {
                    CarModelId = 13,
                    EquipmentId = 1, // Autopilot
                },
                new CarModel_Equipment
                {
                    CarModelId = 13,
                    EquipmentId = 2, // Full Self-Driving (FSD) Package
                },
                new CarModel_Equipment
                {
                    CarModelId = 13,
                    EquipmentId = 4, // Heated Seats
                },
                new CarModel_Equipment
                {
                    CarModelId = 13,
                    EquipmentId = 9, // 19\" Wheels
                },


                // Cybertruck Standard AWD
                new CarModel_Equipment
                {
                    CarModelId = 14,
                    EquipmentId = 1, // Autopilot
                },
                new CarModel_Equipment
                {
                    CarModelId = 14,
                    EquipmentId = 2, // Full Self-Driving (FSD) Package
                },
                new CarModel_Equipment
                {
                    CarModelId = 14,
                    EquipmentId = 4, // Heated Seats
                },
                new CarModel_Equipment
                {
                    CarModelId = 14,
                    EquipmentId = 9, // 19\" Wheels
                },


                 // Cybertruck Cyber-beast RWD
                 new CarModel_Equipment
                 {
                     CarModelId = 15,
                     EquipmentId = 1, // Autopilot
                 },
                new CarModel_Equipment
                {
                    CarModelId = 15,
                    EquipmentId = 2, // Full Self-Driving (FSD) Package
                },
                new CarModel_Equipment
                {
                    CarModelId = 15,
                    EquipmentId = 3, // Premium Interior
                },
                new CarModel_Equipment
                {
                    CarModelId = 15,
                    EquipmentId = 4, // Heated Seats
                },
                new CarModel_Equipment
                {
                    CarModelId = 15,
                    EquipmentId = 6, // Supercharging
                },
                new CarModel_Equipment
                {
                    CarModelId = 15,
                    EquipmentId = 11, // 20\" Sport Wheels
                }
            );
        }
    }
}
