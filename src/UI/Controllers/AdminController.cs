using Microsoft.AspNetCore.Mvc;
using UI.Contracts.Services;
using UI.Database;
using UI.Models;
using UI.Models.ViewModels;

namespace UI.Controllers
{
    public class AdminController : Controller
    {
        private readonly ILogger<AccountController> _logger;
        private readonly IUserService _userService;
        private readonly ICategoryService _categoryService;

        public AdminController(ILogger<AccountController> logger, IUserService userService,ICategoryService categoryService)
        {
            _logger = logger;
            _userService = userService;
            _categoryService = categoryService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var onlineUserFullData = _userService.GetUserById(InMemoryDatabase.OnlineUser!.Id);

            if (onlineUserFullData.IsSuccess)
            {
                ViewBag.OnlineUser = onlineUserFullData.Data;

                // var model = new UserInfoViewModel
                // {
                //     Id = onlineUserFullData.Data!.Id,
                //     Firstname = onlineUserFullData.Data.Firstname,
                //     Lastname = onlineUserFullData.Data.Lastname,
                //     Username = onlineUserFullData.Data.Username,
                //     Role = onlineUserFullData.Data.Role,
                //     PhoneNumber = onlineUserFullData.Data.PhoneNumber,
                //     CreatedAt = onlineUserFullData.Data.CreatedAt
                // };
                // return View(model);
            }
            else
            {
                ViewBag.Error = onlineUserFullData.Message;
            }

            return View();
        }

        public IActionResult UsersList()
        {
            var usersList = _userService.GetUsersListForAdmin(InMemoryDatabase.OnlineUser!.Id);

            var model = usersList.Select(u => new UserInfoViewModel()
            {
                Id = u.Id,
                Firstname = u.Firstname,
                Lastname = u.Lastname,
                Username = u.Username,
                Role = u.Role,
                PhoneNumber = u.PhoneNumber,
                CreatedAt = u.CreatedAt
            }).ToList();

            return View(model);
        }


        public IActionResult CategoriesList()
        {
            var categoriesList = _categoryService.GetAll();

            return View(categoriesList);
        }

    }
}
