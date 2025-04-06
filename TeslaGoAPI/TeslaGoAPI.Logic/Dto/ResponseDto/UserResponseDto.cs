using TeslaGoAPI.Logic.Dto.Abstract;

namespace TeslaGoAPI.Logic.Dto.ResponseDto
{
    public class UserResponseDto : BaseResponseDto
    {
        public string Name { get; set; } = string.Empty;
        public string Surname { get; set; } = string.Empty;
        public string? DrivingLicenseNumber { get; set; }
        public string EmailAddress { get; set; } = string.Empty;
        public DateTime RegisteredDate { get; set; }
        public DateTime DateOfBirth { get; set; }
        public AddressResponseDto? Address { get; set; } = default!;
        public ICollection<ReservationResponseDto> Reservations { get; set; } = [];
        public ICollection<string?> UserRoles { get; set; } = [];
    }
}
