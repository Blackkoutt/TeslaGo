﻿using System.ComponentModel.DataAnnotations;
using TeslaGoAPI.DB.Entities.Abstract;

namespace TeslaGoAPI.DB.Entities
{
    public class BodyType : BaseEntity
    {
        [MaxLength(80)]
        public string Name { get; set; } = string.Empty;
        public ICollection<CarModel> CarModels { get; set; } = [];
    }
}
