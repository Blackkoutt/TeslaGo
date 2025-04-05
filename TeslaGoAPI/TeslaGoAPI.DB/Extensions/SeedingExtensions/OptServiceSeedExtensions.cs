using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TeslaGoAPI.DB.Entities;

namespace TeslaGoAPI.DB.Extensions.SeedingExtensions
{
    public static class OptServiceSeedExtensions
    {
        public static void Seed(this EntityTypeBuilder<OptService> entityBuilder)
        {
            entityBuilder.HasData(
                new OptService
                {
                    Id = 1,
                    Name = "Full Insurance",
                    Description = "Comprehensive insurance coverage including damage, theft, and third-party liability.",
                    Price = 250.00m
                },
                new OptService
                {
                    Id = 3,
                    Name = "Child Car Seat",
                    Description = "Safe and comfortable child car seat suitable for different age groups.",
                    Price = 50.00m 
                },
                new OptService
                {
                    Id = 4,
                    Name = "Roadside Assistance",
                    Description = "24/7 roadside assistance in case of emergencies like breakdowns or accidents.",
                    Price = 199.00m  
                },
                new OptService
                {
                    Id = 5,
                    Name = "Extra Driver",
                    Description = "Add an additional driver to the rental for no extra charge for the duration of the rental period.",
                    Price = 25.00m 
                }
            );
        }
    }
}
