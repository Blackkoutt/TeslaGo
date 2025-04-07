using System.Text.Json.Serialization;

namespace TeslaGoAPI.Logic.Enums
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum Status
    {
        Active,
        Canceled,
        Expired,
        Unknown
    }
}
