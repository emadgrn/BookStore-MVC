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
    }
}
