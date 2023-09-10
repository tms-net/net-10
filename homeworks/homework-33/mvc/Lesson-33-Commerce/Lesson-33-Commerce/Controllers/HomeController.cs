using Lesson_33_Commerce.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Lesson_33_Commerce.Controllers
{
    public class HomeController : Controller
    {
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

        public IActionResult Shop(int? page = null)
        {
            var viewModel = new ShopViewModel
            {
                Pagination = new PaginationViewModel
                {
                    CurrentPage = page ?? 1,
                    PageCount = 3
                }
            };

            return View(viewModel);
        }

        public IActionResult Product(string id)
        {
            return NotFound();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}