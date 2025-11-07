using UI.Models.DTOs.User;

namespace UI.Contracts.Repositories;

public interface IUserRepository
{
    List<GetUserDto> GetAll();
    GetUserDto? GetById(int id);
    GetUserSummaryDto? Login(string username, string password);
    GetUserSummaryDto? Register(CreateUserDto model);
    bool UsernameExists(string username);
    public bool Update(int userId, UpdateUserDto model);
    public UpdateUserDto? GetUpdateUserDetailsById(int id);
    public bool DeleteById(int userId);



}