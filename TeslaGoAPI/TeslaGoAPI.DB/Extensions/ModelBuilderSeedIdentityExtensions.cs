using Bogus;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using TeslaGoAPI.DB.Entities;

namespace TeslaGoAPI.DB.Extensions
{
    public static class ModelBuilderSeedIdentityExtensions
    {
        public static void SeedUsers(this ModelBuilder builder, DateTime today)
        {
            var hasher = new PasswordHasher<User>();
            var faker = new Faker();
            var user1 = new User
            {
                Id = 1,
                Name = "Admin",
                Surname = "Admin",
                Email = "admin@gmail.com",
                UserName = "admin@gmail.com",
                NormalizedEmail = "admin@gmail.com".ToUpper(),
                NormalizedUserName = "admin@gmail.com".ToUpper(),
                EmailConfirmed = true,
                ConcurrencyStamp = "37dfae4c-bb56-41e0-81a1-20a09eb89a65",
                RegisteredDate = today.AddMonths(-3), 
                DateOfBirth = new DateTime(2000, 4, 3),
                DrivingLicenseNumber = faker.Lorem.Random.AlphaNumeric(10).ToUpper(),
                AddressId = 1,
            };
            user1.PasswordHash = hasher.HashPassword(user1, "admin123");

            var user2 = new User
            {
                Id = 2,
                Name = "Jan",
                Surname = "Kowalski",
                Email = "jan.kowalski@gmail.com",
                UserName = "jan.kowalski@gmail.com",
                ConcurrencyStamp = " 9f0a42ad-8b69-4b33-b42e-87d16f84bfe5",
                NormalizedEmail = "jan.kowalski@gmail.com".ToUpper(),
                NormalizedUserName = "jan.kowalski@gmail.com".ToUpper(),
                RegisteredDate = today.AddMonths(-1).AddDays(-10),
                EmailConfirmed = true,
                DateOfBirth = new DateTime(1985, 2, 1),
                DrivingLicenseNumber = faker.Lorem.Random.AlphaNumeric(10).ToUpper(),
                AddressId = 12,
            };
            user2.PasswordHash = hasher.HashPassword(user2, "789qaz");

            builder.Entity<User>().HasData(
                user1, user2
            );
        }

        public static void SeedRoles(this ModelBuilder builder)
        {
            builder.Entity<Role>().HasData(
               new Role
               {
                   Id = 1,
                   Name = "Admin",
                   NormalizedName = "Admin".ToUpper(),
                   Description = "Admin role"
               },
               new Role
               {
                   Id = 2,
                   Name = "User",
                   NormalizedName = "User".ToUpper(),
                   Description = "User role"
               }
           );
        }

        public static void SeedUsersInRoles(this ModelBuilder builder)
        {
            builder.Entity<IdentityUserRole<int>>().HasData(
               new IdentityUserRole<int>
               {
                   UserId = 1,
                   RoleId = 1,
               },
               new IdentityUserRole<int>
               {
                   UserId = 2,
                   RoleId = 2,
               }
            );
        }
    }
}
