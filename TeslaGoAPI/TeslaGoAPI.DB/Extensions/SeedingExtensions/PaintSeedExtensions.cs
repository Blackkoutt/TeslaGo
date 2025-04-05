using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TeslaGoAPI.DB.Entities;

namespace TeslaGoAPI.DB.Extensions.SeedingExtensions
{
    public static class PaintSeedExtensions
    {
        public static void Seed(this EntityTypeBuilder<Paint> entityBuilder)
        {
            entityBuilder.HasData(
                new Paint
                {
                    Id = 1,
                    Name = "Pearl White",
                    ColorHex = "#ffffff"
                },
                new Paint
                {
                    Id = 2,
                    Name = "Solid Black",
                    ColorHex = "#000000"
                },
                new Paint
                {
                    Id = 3,
                    Name = "Deep Blue Metallic",
                    ColorHex = "#235598"
                },
                new Paint
                {
                    Id = 4,
                    Name = "Stealth Grey",
                    ColorHex = "#212127"
                },
                new Paint
                {
                    Id = 5,
                    Name = "QuickSilver",
                    ColorHex = "#87858e"
                },
                new Paint
                {
                    Id = 6,
                    Name = "Ultra Red",
                    ColorHex = "#b6151f"
                },
                new Paint
                {
                    Id = 7,
                    Name = "Midnight Cherry Red",
                    ColorHex = "#740415"
                }
            );
        }
    }
}
