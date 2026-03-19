using tinyUrl.Application.Contracts;
using tinyUrl.Application.DTOs;

namespace tinyUrl.Infrastructure.Services
{
    public class UserLogin : IUserLogin
    {
        public Task<string> Login(LoginModel loginModel)
        {
            throw new NotImplementedException();
        }
    }
}
