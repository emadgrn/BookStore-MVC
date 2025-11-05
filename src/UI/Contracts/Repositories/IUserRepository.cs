using UI.Models.DTOs.User;

namespace UI.Contracts.Repositories;

public interface IUserRepository
{
    List<GetUserDto> GetAll();
    GetUserSummaryDto? Login(string username, string password);
    GetUserSummaryDto? Register(CreateUserDto model);
    bool UsernameExists(string username);


}