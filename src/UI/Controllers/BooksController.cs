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
            if (model.ImageFile != null && model.ImageFile.Length > 0)
            {
                var uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images/books");
                Directory.CreateDirectory(uploadsFolder);

                var uniqueFileName = Guid.NewGuid().ToString() + Path.GetExtension(model.ImageFile.FileName);
                var filePath = Path.Combine(uploadsFolder, uniqueFileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    model.ImageFile.CopyTo(stream);
                }

                var modelDto = new CreateBookDto()
                {
                    Title = model.Title,
                    AuthorName = model.AuthorName,
                    PagesCount = model.PagesCount,
                    Price=model.Price,
                    CategoryId = model.CategoryId,
                    ImageUrl = filePath
                };
                _bookService.CreateNewBook(modelDto);
            }

            return RedirectToAction("Index","Home");
        }
    }
}
