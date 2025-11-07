using UI.Contracts.Repositories;
using UI.Contracts.Services;
using UI.Data.Repositories;
using UI.Models.DTOs.User;
using UI.Models.Entities._common;
using UI.Models.Entities.Enums;
using UI.Models.ViewModels;

namespace UI.Services
{
    public class UserService(IUserRepository userRepo): IUserService
    {
        public List<GetUserDto> GetUsersListForAdmin(int id)
        {
            return userRepo.GetAll()
                .Where(u => u.Id != id)
                .ToList();
        }

        public Result<GetUserSummaryDto> Login(string username, string password)
        {
            var loginData = userRepo.Login(username, password);

            if (loginData is not null)
            {
                return Result<GetUserSummaryDto>.Success("لاگین با موفقیت انجام شد.", loginData);

            }
            else
            {
                return Result<GetUserSummaryDto>.Failure("نام کاربری یا کلمه عبور اشتباه می باشد.");  
            }
        }

        public Result<GetUserSummaryDto> Register(CreateUserDto model)
        {
            var usernameExist = userRepo.UsernameExists(model.Username);

            if (usernameExist)
            {
                return Result<GetUserSummaryDto>.Failure("کاربر با این نام کاربری موجود می باشد.");
            }

            var registerData = userRepo.Register(model);

            if (registerData is not null)
            {
                return Result<GetUserSummaryDto>.Success("ثبت نام با موفقیت انجام شد.", registerData);

            }
            else
            {
                return Result<GetUserSummaryDto>.Failure("ثبت نام با مشکل مواجه شد.");
            }
        }

        public Result<GetUserDto> GetUserById(int id)
        {
            var userDto = userRepo.GetById(id);

            if (userDto is not null)
            {
                return Result<GetUserDto>.Success("",userDto);
            }
            else
            {
                return Result<GetUserDto>.Failure($"کاربر با این آیدی {id} وجود ندارد");
            }
        }

        public UpdateUserDto? GetUpdateUserDetails(int userId)
        {
            return userRepo.GetUpdateUserDetailsById(userId);
        }

        public Result<bool> Update(int userId, UpdateUserDto model)
        {
            var result = userRepo.Update(userId, model);

            if (result)
            {
                return Result<bool>.Success("اطلاعات کاربر با موفقیت به‌روزرسانی شد.");
            }
            else
            {
                return Result<bool>.Failure("به‌روزرسانی اطلاعات کاربر با خطا مواجه شد.");
            }
        }

        public bool DeleteUser(int userId)
        {
            return userRepo.DeleteById(userId);
        }
    }
}
