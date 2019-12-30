using System.Threading.Tasks;

namespace redis.cache.practice.services.crawler
{
    public interface ITriggerCrawler
    {
        Task CrawlHtmlAsync(CrawlerType type);
    }
}
