namespace tinyUrl.Application.Contracts
{
    public interface IShortUrlGenerator
    {
        Task<string> CreateShortUrl(string LongUrl);
    }
}
