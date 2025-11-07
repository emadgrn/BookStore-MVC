using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UI.Contracts.Services;
using UI.Models.DTOs.User;
using UI.Models.ViewModels;
using UI.Services;

namespace UI.Controllers
{
    public class UserController : Controller
    {
        private readonly ILogger<AccountController> _logger;
        private readonly IUserService _userService;

        public UserController(ILogger<AccountController> logger, IUserService userService)
        {
            _logger = logger;
            _userService = userService;
        }




        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(RegisterViewModel model)
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

            _userService.Register(userModel);
            return RedirectToAction("UsersList", "Admin");
        }


        [HttpGet]
        public IActionResult Update(int id)
        {
            var result = _userService.GetUpdateUserDetails(id);
            return View(result);
        }

        [HttpPost]
        public IActionResult Update(UpdateUserDto model)
        {
            var result = _userService.Update(model.Id, model);
            if (result.IsSuccess)
            {
                return RedirectToAction("UsersList", "Admin");
            }
            else
            {
                ViewBag.Error = result.Message;
            }
            return View(model);
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            _userService.DeleteUser(id);

            return RedirectToAction("UsersList", "Admin");
        }
    }
}
