using System.ComponentModel.DataAnnotations;
using TeslaGoAPI.Logic.Query.Abstract;

namespace TeslaGoAPI.Logic.Query
{
    public class CarQuery : QueryObject
    {
        public string? VIN { get; set; }
        public string? RegistrationNr { get; set; }
        public int? ModelId { get; set; }
        public int? PaintId { get; set; }
        public int? LocationId { get; set; }
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }
        public bool? IsAvailable { get; set; } = false;
    }
}
