namespace tinyUrl.Domain.Entities
{
    public class ShortenedUrl
    {
        public Guid Id { get; set; }
        public required string LongUrl { get; set; }
        public required string ShortCode { get; set; }
        public DateTime CreatedAtUtc { get; set; }

        // Relationship to a User (Optional)
        public Guid? UserId { get; set; }
        public User? User { get; set; }
    }
}
