using System.Text.Json.Serialization;

namespace TeslaGoAPI.Logic.Dto.Abstract
{
    public abstract class BaseResponseDto : IResponseDto
    {
        [JsonPropertyOrder(-1)]
        public int Id { get; set; }
    }
}
