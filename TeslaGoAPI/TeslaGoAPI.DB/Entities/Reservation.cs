﻿using System.ComponentModel.DataAnnotations.Schema;
using TeslaGoAPI.DB.Entities.Abstract;

namespace TeslaGoAPI.DB.Entities
{
    public class Reservation : BaseEntity, IAuthEntity, IDateableEntity, ISoftDeleteable, IUpdateableEntity
    {
        public DateTime ReservationDate { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        [Column(TypeName = "decimal(9,2)")]
        public decimal TotalCost { get; set; }
        public int PickupLocationId { get; set; }
        public int ReturnLocationId { get; set; }
        public int UserId { get; set; }
        public User User { get; set; } = default!;
        public int CarModelId { get; set; }
        public CarModel CarModel { get; set; } = default!;
        public int? CarId { get; set; }
        public Car? Car { get; set; } = default!;
        public int PaymentMethodId { get; set; }
        public PaymentMethod PaymentMethod { get; set; } = default!;
        public ICollection<OptService> OptServices { get; set; } = [];
        public Location PickupLocation { get; set; } = default!;
        public Location ReturnLocation { get; set; } = default!;
        public ICollection<CarAvailabilityIssue> CarAvailabilityIssues { get; set; } = [];
        public bool IsDeleted { get; set; } = false;
        public DateTime? DeleteDate { get; set; } = null;
        public bool IsUpdated { get; set; } = false;
        public DateTime? UpdateDate { get; set; } = null;

        [NotMapped]
        public bool IsActive => StartDate < DateTime.Now && EndDate > DateTime.Now;

        [NotMapped]
        public bool IsExpired => EndDate < DateTime.Now;
    }
}
