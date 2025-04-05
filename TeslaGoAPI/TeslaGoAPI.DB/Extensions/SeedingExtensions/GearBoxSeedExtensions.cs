using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TeslaGoAPI.DB.Entities;

namespace TeslaGoAPI.DB.Extensions.SeedingExtensions
{
    public static class GearBoxSeedExtensions
    {
        public static void Seed(this EntityTypeBuilder<GearBox> entityBuilder)
        {
            entityBuilder.HasData(
                 new GearBox
                 {
                     Id = 1,
                     Name = "Single-Speed",
                     NumberOfGears = 1,                 
                 }
            );
        }
    }
}
