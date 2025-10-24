namespace MyNewsPage.Models
{
    public class NewsItem
    {
        public string Title { get; set; } = string.Empty;
        public string Summary { get; set; } = string.Empty;
        public string Url { get; set; } = string.Empty;
        public string ImageUrl { get; set; } = string.Empty;
        public DateTime PublishedDate { get; set; }
        public string Category { get; set; } = string.Empty;
    }
}