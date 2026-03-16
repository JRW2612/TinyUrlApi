namespace tinyUrl.Application.Contracts
{
    public interface IUserLogin
    {
        Task<string> Login(string username, string password);
    }
}
