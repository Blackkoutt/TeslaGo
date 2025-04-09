namespace TeslaGoAPI.Logic.Helpers
{
    public class BlobResponseDto
    {
        public string FileName { get; set; } = string.Empty;
        public string ContentType { get; set; } = string.Empty;
        public byte[] Data { get; set; } = default!;
    }
}
