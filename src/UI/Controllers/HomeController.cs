using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using UI.Contracts.Services;
using UI.Models;
using UI.Models.ViewModels;

namespace UI.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly IBookService _bookService;
    private readonly ICategoryService _categoryService;

    public HomeController(ILogger<HomeController> logger, IBookService bookService,ICategoryService categoryService)
    {
        _logger = logger;
        _bookService = bookService;
        _categoryService = categoryService;
    }

    public IActionResult Index()
    {
        var model = new HomeViewModel
        {
            LatestBooks = _bookService.GetLimitedLatestBooks(),
            Categories = _categoryService.GetAll()
        };

        return View(model);
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
