using Bogus;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TeslaGoAPI.DB.Entities;

namespace TeslaGoAPI.DB.Extensions.SeedingExtensions
{
    public static class AddressSeedExtensions
    {
        public static void Seed(this EntityTypeBuilder<Address> entityBuilder)
        {
            var faker = new Faker();
            entityBuilder.HasData(
               new Address
               {
                   Id = 1,
                   Street = "Carretera de l'Aeroport",
                   HouseNr = faker.Address.BuildingNumber(),
                   ZipCode = faker.Address.ZipCode(),
                   CityId = 1 // Palma
               },
               new Address
               {
                   Id = 2,
                   Street = "Carrer de la Riera",
                   HouseNr = faker.Address.BuildingNumber(),
                   ZipCode = faker.Address.ZipCode(),
                   CityId = 1 // Palma
               },
               new Address
               {
                   Id = 3,
                   Street = "Cami de Ronda",
                   HouseNr = faker.Address.BuildingNumber(),
                   ZipCode = faker.Address.ZipCode(),
                   CityId = 2 // Alcudia
               },
               new Address
               {
                   Id = 4,
                   Street = "Via Portugal",
                   HouseNr = faker.Address.BuildingNumber(),
                   ZipCode = faker.Address.ZipCode(),
                   CityId = 3 // Manacor
               },
                new Address
                {
                    Id = 5,
                    Street = "Carrer de la Rosa",
                    HouseNr = faker.Address.BuildingNumber(),
                    FlatNr = faker.Random.Short(1, 200),
                    ZipCode = faker.Address.ZipCode(),
                    CityId = 4 // Inca
                },
                new Address
                {
                    Id = 6,
                    Street = "Carrer del Sol",
                    HouseNr = faker.Address.BuildingNumber(),
                    FlatNr = faker.Random.Short(1, 200),
                    ZipCode = faker.Address.ZipCode(),
                    CityId = 5 // Santanyí
                },
                new Address
                {
                    Id = 7,
                    Street = "Carrer de la Ciutat",
                    HouseNr = faker.Address.BuildingNumber(),
                    FlatNr = faker.Random.Short(1, 200),
                    ZipCode = faker.Address.ZipCode(),
                    CityId = 6 // Sóller
                },
                new Address
                {
                    Id = 8,
                    Street = "Carrer de la Lluna",
                    HouseNr = faker.Address.BuildingNumber(),
                    FlatNr = faker.Random.Short(1, 200),
                    ZipCode = faker.Address.ZipCode(),
                    CityId = 7 // Magaluf
                },
                new Address
                {
                    Id = 9,
                    Street = "Carrer del Mar",
                    HouseNr = faker.Address.BuildingNumber(),
                    FlatNr = faker.Random.Short(1, 200),
                    ZipCode = faker.Address.ZipCode(),
                    CityId = 8 // Porto Cristo
                },
                new Address
                {
                    Id = 10,
                    Street = "Carrer de la Mediterrània",
                    HouseNr = faker.Address.BuildingNumber(),
                    FlatNr = faker.Random.Short(1, 200),
                    ZipCode = faker.Address.ZipCode(),
                    CityId = 9 // Campos
                },
                new Address
                {
                    Id = 11,
                    Street = "Carrer de la Palma",
                    HouseNr = faker.Address.BuildingNumber(),
                    FlatNr = faker.Random.Short(1, 200),
                    ZipCode = faker.Address.ZipCode(),
                    CityId = 10 // Marratxí
                },
                new Address
                {
                    Id = 12,
                    Street = "Krakowskie Przedmieście",
                    HouseNr = faker.Address.BuildingNumber(),
                    FlatNr = faker.Random.Short(1, 200),
                    ZipCode = faker.Address.ZipCode(),
                    CityId = 11 // Warsaw
                },
                new Address
                {
                    Id = 13,
                    Street = "Strzelecka",
                    HouseNr = faker.Address.BuildingNumber(),
                    FlatNr = faker.Random.Short(1, 200),
                    ZipCode = faker.Address.ZipCode(),
                    CityId = 12 // Kraków
                },
                new Address
                {
                    Id = 14,
                    Street = "Calle Gran Vía",
                    HouseNr = faker.Address.BuildingNumber(),
                    FlatNr = faker.Random.Short(1, 200),
                    ZipCode = faker.Address.ZipCode(),
                    CityId = 13 // Madrid
                },
                new Address
                {
                    Id = 15,
                    Street = "Passeig de Gràcia",
                    HouseNr = faker.Address.BuildingNumber(),
                    FlatNr = faker.Random.Short(1, 200),
                    ZipCode = faker.Address.ZipCode(),
                    CityId = 14 // Barcelona
                },
                new Address
                {
                    Id = 16,
                    Street = "Berliner Strasse",
                    HouseNr = faker.Address.BuildingNumber(),
                    FlatNr = faker.Random.Short(1, 200),
                    ZipCode = faker.Address.ZipCode(),
                    CityId = 15 // Berlin
                },
                new Address
                {
                    Id = 17,
                    Street = "Maximilianstrasse",
                    HouseNr = faker.Address.BuildingNumber(),
                    FlatNr = faker.Random.Short(1, 200),
                    ZipCode = faker.Address.ZipCode(),
                    CityId = 16 // Munich
                },
                new Address
                {
                    Id = 18,
                    Street = "Rue Monge",
                    HouseNr = faker.Address.BuildingNumber(),
                    FlatNr = faker.Random.Short(1, 200),
                    ZipCode = faker.Address.ZipCode(),
                    CityId = 17 // Paris
                },
                new Address
                {
                    Id = 19,
                    Street = "Rue Vauban",
                    HouseNr = faker.Address.BuildingNumber(),
                    FlatNr = faker.Random.Short(1, 200),
                    ZipCode = faker.Address.ZipCode(),
                    CityId = 18 // Lyon
                },
                new Address
                {
                    Id = 20,
                    Street = "Via Torino",
                    HouseNr = faker.Address.BuildingNumber(),
                    FlatNr = faker.Random.Short(1, 200),
                    ZipCode = faker.Address.ZipCode(),
                    CityId = 19 // Rome
                },
                new Address
                {
                    Id = 21,
                    Street = "Via Brera",
                    HouseNr = faker.Address.BuildingNumber(),
                    FlatNr = faker.Random.Short(1, 200),
                    ZipCode = faker.Address.ZipCode(),
                    CityId = 20 // Milan
                }
            );
        }
    }
}
