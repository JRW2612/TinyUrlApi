namespace tinyUrl.Application.DTOs
{
    public record CreateShortUrlRequest
    {
        // The long URL the user wants to shorten
        public required string LongUrl { get; set; }

        // Optional: If the user wants a specific code (e.g., tiny.url/my-link)
        public string? CustomShortCodeAlias { get; set; }
    }
}
