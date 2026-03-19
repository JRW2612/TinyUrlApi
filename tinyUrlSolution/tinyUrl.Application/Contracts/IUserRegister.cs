using tinyUrl.Application.DTOs;

namespace tinyUrl.Application.Contracts
{
    public interface IUserRegister
    {
        Task<string> UserRegistration(UserModel userModel);
    }
}
