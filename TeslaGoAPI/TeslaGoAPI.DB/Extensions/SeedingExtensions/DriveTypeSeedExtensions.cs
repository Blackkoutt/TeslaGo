using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace TeslaGoAPI.DB.Extensions.SeedingExtensions
{
    public static class DriveTypeSeedExtensions
    {
        public static void Seed(this EntityTypeBuilder<Entities.DriveType> entityBuilder)
        {
            entityBuilder.HasData(
                new Entities.DriveType
                {
                    Id = 1,
                    Name = "RWD",
                    Description = "Rear-Wheel Drive"
                },
                new Entities.DriveType
                {
                    Id = 2,
                    Name = "AWD",
                    Description = "All-Wheel Drive"
                }
            );
        }
    }
}
