namespace tinyUrl.Application.Contracts
{
    public interface ILongUrlGenerator
    {
        Task<string> GenerateLongUrl(string ShortCode);
    }
}
