using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TeslaGoAPI.DB.Entities;

namespace TeslaGoAPI.DB.Extensions.SeedingExtensions
{
    public static class PaymentMethodSeedExtensions
    {
        public static void Seed(this EntityTypeBuilder<PaymentMethod> entityBuilder)
        {
            entityBuilder.HasData(
                new PaymentMethod
                {
                    Id = 1,
                    Name = "Credit Card"
                },
                new PaymentMethod
                {
                    Id = 2,
                    Name = "Bank Transfer"
                },
                new PaymentMethod
                {
                    Id = 3,
                    Name = "PayPal"
                },
                new PaymentMethod
                {
                    Id = 4,
                    Name = "Apple Pay"
                },
                new PaymentMethod
                {
                    Id = 5,
                    Name = "Google Pay"
                },
                new PaymentMethod
                {
                    Id = 6,
                    Name = "Cash on Delivery"
                }
            );
        }
    }
}
