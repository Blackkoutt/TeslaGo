﻿using System.Text.Json.Serialization;

namespace TeslaGoAPI.Logic.Enums
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum Status
    {
        Active,
        Deleted,
        Expired,
        Unknown
    }
}
