using TeslaGoAPI.Logic.Enums;
using TeslaGoAPI.Logic.Query.Abstract;

namespace TeslaGoAPI.Logic.Query
{
    public class ReservationQuery : QueryObject, IDateableQuery
    {
        public Status? Status { get; set; }
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }
        public DateTime? FromReservationDate { get; set; }
        public DateTime? ToReservationDate { get; set; }
        public decimal? MinPrice { get; set; }
        public decimal? MaxPrice { get; set; }
        public string? UserName { get; set; }
        public int? PickupLocationId { get; set; }
        public int? ReturnLocationId { get; set; }
        public int? CarModelId { get; set; }
        public int? CarId { get; set; }
        public int? PaymentMethodId { get; set; }
    }
}
