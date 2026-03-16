namespace tinyUrl.Application.Contracts
{
    public interface IShortCodeGenerator
    {
        Task<string> Generate(int length = 7);
    }
}
