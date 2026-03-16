using tinyUrl.Domain.DTOs;

namespace tinyUrl.Application.Contracts
{
    public interface IUserRegister
    {
        Task<string> UserRegistration(UserModel userModel);
    }
}
