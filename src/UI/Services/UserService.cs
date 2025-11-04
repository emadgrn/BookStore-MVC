using UI.Contracts.Repositories;
using UI.Contracts.Services;
using UI.Models.DTOs.User;
using UI.Models.Entities.Enums;

namespace UI.Services
{
    public class UserService(IUserRepository userRepo): IUserService
    {
        public RoleEnum Login(LoginDto loginData)
        {
            throw new NotImplementedException();
        }

        public void Register(CreateUserDto model)
        {
            throw new NotImplementedException();
        }
    }
}
