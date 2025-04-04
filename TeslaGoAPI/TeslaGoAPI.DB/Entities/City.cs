﻿using System.ComponentModel.DataAnnotations;
using TeslaGoAPI.DB.Entities.Abstract;

namespace TeslaGoAPI.DB.Entities
{
    public class City : BaseEntity
    {
        [MaxLength(80)]
        public string Name { get; set; } = string.Empty;
        public int CountryId { get; set; }
        public Country Country { get; set; } = default!;
        public ICollection<Address> Addresses { get; set; } = [];
    }
}
