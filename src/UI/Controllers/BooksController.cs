using Microsoft.AspNetCore.Mvc;
using UI.Contracts.Services;
using UI.Models.DTOs;
using UI.Models.ViewModels;
using UI.Services;

namespace UI.Controllers
{
    public class BooksController : Controller
    {
        private readonly ILogger<BooksController> _logger;
        private readonly IBookService _bookService;
        private readonly ICategoryService _categoryService;

        public BooksController(ILogger<BooksController> logger, IBookService bookService,
            ICategoryService categoryService)
        {
            _logger = logger;
            _bookService = bookService;
            _categoryService = categoryService;
        }

        [HttpGet]
        public IActionResult Create()
        {
            var categories = _categoryService.GetAll();
            ViewBag.Categories = categories;
            return View();
        }

        [HttpPost]
        public IActionResult Create(CreateBookViewModel model)
        {
            _bookService.CreateNewBook(model);
            return RedirectToAction("Index","Home");
        }
    }
}
