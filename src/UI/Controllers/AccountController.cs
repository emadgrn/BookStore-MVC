using Microsoft.AspNetCore.Mvc;
using UI.Contracts.Services;
using UI.Database;
using UI.Models.ViewModels;
using UI.Models;
using UI.Models.DTOs.User;
using UI.Models.Entities.Enums;
using UI.Services;

namespace UI.Controllers
{
    public class AccountController : Controller
    {
        private readonly ILogger<AccountController> _logger;
        private readonly IUserService _userService;

        public AccountController(ILogger<AccountController> logger, IUserService userService)
        {
            _logger = logger;
            _userService = userService;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View(new LoginViewModel());
        }

        [HttpPost]
        public IActionResult Login(LoginViewModel model)
        {
            var loginResult = _userService.Login(model.Username, model.Password);

            if (loginResult.IsSuccess)
            {
                InMemoryDatabase.OnlineUser = new OnlineUser
                {
                    Id = loginResult.Data!.Id,
                    Username = loginResult.Data.Username,
                    Role = loginResult.Data.Role,
                    Fullname = loginResult.Data.Fullname
                };

                if (loginResult.Data!.Role == RoleEnum.Admin)
                {
                    return RedirectToAction("Index", "Admin");
                }
                else if (loginResult.Data!.Role == RoleEnum.Customer)
                {
                    return RedirectToAction("Index", "Customer");

                }
            }
            else
            {
                ViewBag.Error = loginResult.Message;
            }

            return View(model);
        }


        [HttpGet]
        public IActionResult Register()
        {
            return View(new RegisterViewModel());
        }
        
        [HttpPost]
        public IActionResult Register(RegisterViewModel model)
        {
            var userModel = new CreateUserDto()
            {
                Firstname = model.Firstname,
                Lastname = model.Lastname,
                PhoneNumber = model.PhoneNumber,
                Password = model.Password,
                Username = model.Username,
                Role = model.Role
            };

            var registerResult = _userService.Register(userModel);

            if (registerResult.IsSuccess)
            {
                InMemoryDatabase.OnlineUser = new OnlineUser
                {
                    Id = registerResult.Data!.Id,
                    Username = registerResult.Data.Username,
                    Role = registerResult.Data.Role,
                    Fullname = registerResult.Data.Fullname
                };

                if (registerResult.Data!.Role == RoleEnum.Admin)
                {
                    return RedirectToAction("Index", "Admin");
                }
                else if (registerResult.Data!.Role == RoleEnum.Customer)
                {
                    return RedirectToAction("Index", "Customer");
                }
            }
            else
            {
                ViewBag.Error = registerResult.Message;
            }

            return View(model);
        }
    }
}