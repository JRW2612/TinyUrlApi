namespace tinyUrl.Application.DTOs
{
    public class ShortUrlResponse
    {
        // The unique slug (e.g., "wL9")
        public required string ShortCode { get; set; }

        // The clickable link (e.g., "https://tiny.url/wL9")
        public required string FullShortUrl { get; set; }

        // The destination URL
        public required string OriginalUrl { get; set; }

        public DateTime CreatedAtUtc { get; set; }
    }
}
