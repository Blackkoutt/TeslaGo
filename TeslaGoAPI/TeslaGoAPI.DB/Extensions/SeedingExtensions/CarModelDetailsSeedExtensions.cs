using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TeslaGoAPI.DB.Entities;

namespace TeslaGoAPI.DB.Extensions.SeedingExtensions
{
    public static class CarModelDetailsSeedExtensions
    {
        public static void Seed(this EntityTypeBuilder<CarModelDetails> entityBuilder)
        {
            entityBuilder.HasData(

                 // Model S Standard RWD
                 new CarModelDetails
                 {
                     Id = 1,
                     ProductionStartYear = new DateTime(2012, 1, 1),
                     ProductionEndYear = null,
                     Description = "Standard Tesla Model S is an all-electric luxury sedan with impressive range and performance.",
                 },

                 // Model S Plaid RWD
                 new CarModelDetails
                 {
                     Id = 2,
                     ProductionStartYear = new DateTime(2021, 1, 1),
                     ProductionEndYear = null,
                     Description = "Tesla Model S Plaid is a high-performance electric sedan with 1,020 horsepower, offering incredible acceleration, a top speed of 322 km/h, and a range of up to 600 km. Perfect blend of speed, luxury, and technology.",
                 },

                 // Model 3 Standard RWD
                 new CarModelDetails
                 {
                     Id = 3,
                     ProductionStartYear = new DateTime(2017, 1, 1),
                     ProductionEndYear = null,
                     Description = "Tesla Model 3 is an all-electric sedan offering a perfect combination of performance, efficiency, and style. With 283 horsepower, it delivers smooth acceleration, a top speed of 225 km/h, and a range of up to 513 km. Ideal for those looking for a reliable and affordable electric vehicle.",
                 },

                 // Model 3 Long Range RWD
                 new CarModelDetails
                 {
                     Id = 4,
                     ProductionStartYear = new DateTime(2017, 1, 1),
                     ProductionEndYear = null,
                     Description = "Tesla Model 3 Long Range RWD is an all-electric sedan offering great efficiency, a range of up to 590 km, and smooth acceleration with 283 horsepower. Perfect for long trips with a top speed of 225 km/h.",
                 },

                 // Model 3 Long Range AWD
                 new CarModelDetails
                 {
                     Id = 5,
                     ProductionStartYear = new DateTime(2017, 1, 1),
                     ProductionEndYear = null,
                     Description = "Tesla Model 3 Long Range AWD is an all-electric sedan offering impressive performance and efficiency. With 346 horsepower, a top speed of 233 km/h, and a range of up to 580 km, it's perfect for those seeking power, range, and versatility.",
                 },

                 // Model 3 Performance AWD
                 new CarModelDetails
                 {
                     Id = 6,
                     ProductionStartYear = new DateTime(2017, 1, 1),
                     ProductionEndYear = null,
                     Description = "Tesla Model 3 Performance is an all-electric sedan offering exhilarating performance and efficiency. With 472 horsepower, a top speed of 261 km/h, and a range of up to 530 km, it's perfect for those seeking speed, power, and precision.",
                 },

                // Model 3 Standard RWD
                new CarModelDetails
                {
                    Id = 7,
                    ProductionStartYear = new DateTime(2020, 1, 1),
                    ProductionEndYear = null,
                    Description = "Tesla Model Y is an all-electric SUV offering a blend of performance and efficiency. With 283 horsepower, a top speed of 217 km/h, and a range of up to 530 km, it’s perfect for those seeking space and sustainability.",
                },

                 // Model Y Long Range RWD
                 new CarModelDetails
                 {
                     Id = 8,
                     ProductionStartYear = new DateTime(2020, 1, 1),
                     ProductionEndYear = null,
                     Description = "Tesla Model Y Long Range RWD is an all-electric SUV offering excellent efficiency and performance. With 283 horsepower, a top speed of 217 km/h, and a range of up to 530 km, it’s perfect for long trips with ample space.",
                 },

                 // Model Y Long Range AWD
                 new CarModelDetails
                 {
                     Id = 9,
                     ProductionStartYear = new DateTime(2020, 1, 1),
                     ProductionEndYear = null,
                     Description = "Tesla Model Y Long Range AWD is an all-electric SUV offering a perfect balance of power, efficiency, and space. With 351 horsepower, a top speed of 217 km/h, and a range of up to 505 km, it’s ideal for long trips and all-weather performance.",
                 },

                 // Model Y Performance AWD
                 new CarModelDetails
                 {
                     Id = 10,
                     ProductionStartYear = new DateTime(2020, 1, 1),
                     ProductionEndYear = null,
                     Description = "Tesla Model Y Performance is an all-electric SUV delivering exceptional speed and performance. With 456 horsepower, a top speed of 250 km/h, and a range of up to 480 km, it offers thrilling acceleration and dynamic handling.",
                 },

                 // Model X Standard AWD
                 new CarModelDetails
                 {
                     Id = 11,
                     ProductionStartYear = new DateTime(2015, 1, 1),
                     ProductionEndYear = null,
                     Description = "Tesla Model X is an all-electric SUV combining top-tier performance, safety, and cutting-edge technology. With 670 horsepower, a top speed of 250 km/h, and a range of up to 560 km, it offers incredible acceleration, spaciousness, and versatility.",
                 },

                  // Model X Plaid AWD
                  new CarModelDetails
                  {
                      Id = 12,
                      ProductionStartYear = new DateTime(2015, 1, 1),
                      ProductionEndYear = null,
                      Description = "Tesla Model X Plaid is a high-performance all-electric SUV that redefines speed and capability. With 1020 horsepower, a top speed of 262 km/h, and a range of up to 560 km, it delivers thrilling acceleration, cutting-edge technology, and unparalleled versatility for families and performance enthusiasts alike.",
                  },

                    // Cybertruck Standard RWD
                    new CarModelDetails
                    {
                        Id = 13,
                        ProductionStartYear = new DateTime(2023, 1, 1),
                        ProductionEndYear = null,
                        Description = "Tesla Cybertruck is an all-electric pickup truck that offers exceptional durability, performance, and utility. With 1020 horsepower, a top speed of 180 km/h, and a range of up to 402 km, it’s built to handle any terrain with advanced technology and futuristic design.",
                    },

                    // Cybertruck Standard AWD
                    new CarModelDetails
                    {
                        Id = 14,
                        ProductionStartYear = new DateTime(2023, 1, 1),
                        ProductionEndYear = null,
                        Description = "Tesla Cybertruck is an all-electric pickup truck that offers exceptional durability, performance, and utility. With 1020 horsepower, a top speed of 180 km/h, and a range of up to 402 km, it’s built to handle any terrain with advanced technology and futuristic design.",
                    },

                    // Cybertruck Cyber-beast RWD
                    new CarModelDetails
                    {
                        Id = 15,
                        ProductionStartYear = new DateTime(2023, 1, 1),
                        ProductionEndYear = null,
                        Description = "Tesla Cybertruck Cyber-beast is an all-electric pickup with unmatched performance. Equipped with three motors, it delivers extreme acceleration, a top speed of 262 km/h, and a range of up to 502 km, designed for the toughest terrains and ultimate power.",
                    }
            );
        }
    }
}
