using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TeslaGoAPI.DB.Entities;

namespace TeslaGoAPI.DB.Extensions.SeedingExtensions
{
    public static class BodyTypeSeedExtensions
    {
        public static void Seed(this EntityTypeBuilder<BodyType> entityBuilder)
        {
            entityBuilder.HasData(
               new BodyType 
               {
                   Id = 1,
                   Name = "Sedan"
               },
               new BodyType
               {
                   Id = 2,
                   Name = "SUV"
               },
               new BodyType
               {
                   Id = 3,
                   Name = "Pickup"
               },
               new BodyType
               {
                   Id = 4,
                   Name = "Roadster"
               }
           );
        }
    }
}
