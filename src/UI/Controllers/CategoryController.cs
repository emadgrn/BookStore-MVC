using Microsoft.AspNetCore.Mvc;
using UI.Contracts.Services;
using UI.Models.DTOs.Category;
using UI.Models.DTOs.User;
using UI.Models.ViewModels;
using UI.Services;

namespace UI.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ILogger<AccountController> _logger;
        private readonly ICategoryService _categoryService;

        public CategoryController(ILogger<AccountController> logger, ICategoryService categoryService)
        {
            _logger = logger;
            _categoryService = categoryService;
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(CreateCategoryViewModel model)
        {
            _categoryService.CreateCategory(model);
            return RedirectToAction("CategoriesList", "Admin");
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            var result = _categoryService.GetCategoryById(id);
            return View(result.Data);
        }

        [HttpPost]
        public IActionResult Update(GetCategoryDto model)
        {
            var result = _categoryService.Update(model.Id, model);
            if (result.IsSuccess)
            {
                return RedirectToAction("CategoriesList", "Admin");
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
            _categoryService.DeleteCategory(id);

            return RedirectToAction("CategoriesList", "Admin");
        }
    }
}
