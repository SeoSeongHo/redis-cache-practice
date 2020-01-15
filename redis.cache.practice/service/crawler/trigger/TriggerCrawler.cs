using System.Threading.Tasks;

namespace redis.cache.practice.services.crawler
{
    public enum CrawlerType
    {
        menu
    }

    public class TriggerCrawler : ITriggerCrawler
    {
        private string url;

        public TriggerCrawler(string url)
        {
            this.url = url;
        }

        public async Task CrawlHtmlAsync(CrawlerType type)
        {
            switch (type)
            {
                case CrawlerType.menu:
                    await new MenuCrawler(url).CrawlHtmlAsync();
                    break;
                default:
                    break;
            }
        }
    }
}
