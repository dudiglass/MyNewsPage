using Microsoft.AspNetCore.Mvc;
using MyNewsPage.Models;
using MyNewsPage.Services;
using System.Diagnostics;

namespace MyNewsPage.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly INewsService _newsService;

        public HomeController(ILogger<HomeController> logger, INewsService newsService)
        {
            _logger = logger;
            _newsService = newsService;
        }

        public async Task<IActionResult> Index()
        {
            try
            {
                var news = await _newsService.GetLatestNewsAsync();
                return View(news);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error loading news: {ex.Message}");
                return View(new List<NewsItem>());
            }
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