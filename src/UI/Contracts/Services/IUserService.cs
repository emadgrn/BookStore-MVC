using UI.Models.DTOs.User;
using UI.Models.Entities._common;
using UI.Models.Entities.Enums;
using UI.Models.ViewModels;

namespace UI.Contracts.Services;

public interface IUserService
{
    
    public Result<GetUserSummaryDto> Login(string mobile, string password);
    public Result<GetUserSummaryDto> Register(CreateUserDto model);
    public Result<GetUserDto> GetUserById(int id);
    public List<GetUserDto> GetUsersListForAdmin(int id);
    public UpdateUserDto? GetUpdateUserDetails(int userId);
    public Result<bool> Update(int userId, UpdateUserDto model);
    public bool DeleteUser(int userId);

}