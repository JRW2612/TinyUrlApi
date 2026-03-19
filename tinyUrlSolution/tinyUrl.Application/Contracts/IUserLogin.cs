using tinyUrl.Application.DTOs;

namespace tinyUrl.Application.Contracts
{
    public interface IUserLogin
    {
        Task<string> Login(LoginModel loginModel);
    }
}
