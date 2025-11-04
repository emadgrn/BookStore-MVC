using UI.Models.DTOs.User;
using UI.Models.Entities.Enums;

namespace UI.Contracts.Services;

public interface IUserService
{
    RoleEnum Login(LoginDto loginData);
    void Register(CreateUserDto model);

}