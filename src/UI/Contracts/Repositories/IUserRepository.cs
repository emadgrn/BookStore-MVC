using UI.Models.DTOs.User;

namespace UI.Contracts.Repositories;

public interface IUserRepository
{
    void Create(CreateUserDto model);
    List<GetUserDto> GetAll();
}