using MyNewsPage.Models;

namespace MyNewsPage.Services
{
    public interface INewsService
    {
        Task<List<NewsItem>> GetLatestNewsAsync();
    }
}