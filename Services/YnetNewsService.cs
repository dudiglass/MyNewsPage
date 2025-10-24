using HtmlAgilityPack;
using MyNewsPage.Models;
using System.Text;

namespace MyNewsPage.Services
{
    public class YnetNewsService : INewsService
    {
        private readonly HttpClient _httpClient;
        private readonly ILogger<YnetNewsService> _logger;

        public YnetNewsService(HttpClient httpClient, ILogger<YnetNewsService> logger)
        {
            _httpClient = httpClient;
            _logger = logger;
            
            // Set Hebrew encoding and user agent
            _httpClient.DefaultRequestHeaders.Add("User-Agent", 
                "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36");
        }

        public async Task<List<NewsItem>> GetLatestNewsAsync()
        {
            var newsItems = new List<NewsItem>();

            try
            {
                // Fetch the main page
                var response = await _httpClient.GetAsync("https://www.ynet.co.il");
                var content = await response.Content.ReadAsStringAsync();

                // Parse HTML
                var doc = new HtmlDocument();
                doc.LoadHtml(content);

                // Extract news items (adjust selectors based on ynet's structure)
                var newsNodes = doc.DocumentNode.SelectNodes("//div[contains(@class, 'story')]//a") ?? 
                               doc.DocumentNode.SelectNodes("//article") ??
                               doc.DocumentNode.SelectNodes("//div[contains(@class, 'item')]");

                if (newsNodes != null)
                {
                    foreach (var node in newsNodes.Take(15)) // Get top 15 news items
                    {
                        try
                        {
                            var titleNode = node.SelectSingleNode(".//h1 | .//h2 | .//h3 | .//span[contains(@class, 'title')] | .//@title");
                            var linkNode = node.Name == "a" ? node : node.SelectSingleNode(".//a");
                            var imgNode = node.SelectSingleNode(".//img");
                            
                            var title = titleNode?.InnerText?.Trim() ?? 
                                       linkNode?.GetAttributeValue("title", "") ?? 
                                       node.InnerText?.Trim()?.Split('\n')[0];
                            
                            if (!string.IsNullOrWhiteSpace(title) && title.Length > 10)
                            {
                                var url = linkNode?.GetAttributeValue("href", "") ?? "";
                                if (!string.IsNullOrEmpty(url) && !url.StartsWith("http"))
                                {
                                    url = "https://www.ynet.co.il" + url;
                                }

                                var imageUrl = imgNode?.GetAttributeValue("src", "") ?? "";
                                if (!string.IsNullOrEmpty(imageUrl) && !imageUrl.StartsWith("http"))
                                {
                                    imageUrl = "https://www.ynet.co.il" + imageUrl;
                                }

                                newsItems.Add(new NewsItem
                                {
                                    Title = System.Net.WebUtility.HtmlDecode(title),
                                    Url = url,
                                    ImageUrl = imageUrl,
                                    PublishedDate = DateTime.Now,
                                    Category = "חדשות",
                                    Summary = "חדשות עדכניות מ-ynet"
                                });
                            }
                        }
                        catch (Exception ex)
                        {
                            _logger.LogWarning($"Error parsing news item: {ex.Message}");
                        }
                    }
                }

                // If no news found with primary method, try alternative approach
                if (newsItems.Count == 0)
                {
                    var allLinks = doc.DocumentNode.SelectNodes("//a[@href]");
                    if (allLinks != null)
                    {
                        foreach (var link in allLinks.Take(20))
                        {
                            var href = link.GetAttributeValue("href", "");
                            var text = link.InnerText?.Trim();
                            
                            if (!string.IsNullOrEmpty(text) && text.Length > 15 && 
                                (href.Contains("articles") || href.Contains("news")))
                            {
                                var fullUrl = href.StartsWith("http") ? href : "https://www.ynet.co.il" + href;
                                
                                newsItems.Add(new NewsItem
                                {
                                    Title = System.Net.WebUtility.HtmlDecode(text),
                                    Url = fullUrl,
                                    PublishedDate = DateTime.Now,
                                    Category = "חדשות",
                                    Summary = "חדשות מ-ynet"
                                });
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error fetching news from ynet: {ex.Message}");
                
                // Return mock data if service fails
                newsItems.Add(new NewsItem
                {
                    Title = "שירות החדשות זמני לא זמין",
                    Summary = "אנא נסה שוב מאוחר יותר",
                    Url = "https://www.ynet.co.il",
                    PublishedDate = DateTime.Now,
                    Category = "הודעה"
                });
            }

            return newsItems.Distinct().ToList();
        }
    }
}