using BusinessLogic.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Presentation.ViewModels;
using System.Diagnostics;

namespace Presentation.Controllers
{
    public class HomeController : Controller
    {
        //private readonly INewsArticleService _newsService;
        //private readonly ICategoryService _categoryService;

        //public HomeController(INewsArticleService newsService, ICategoryService categoryService)
        //{
        //    _newsService = newsService;
        //    _categoryService = categoryService;
        //}


        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
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
}
