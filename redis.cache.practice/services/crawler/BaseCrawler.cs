using redis.cache.practice.services.redis;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace redis.cache.practice.services.crawler
{
    public abstract class BaseCrawler
    {
        protected RedisCache redisCache;
        protected string url;

        public BaseCrawler(string url, RedisCache redisCache)
        {
            this.url = url;
            this.redisCache = redisCache;
        }

        public async Task CrawlHtmlAsync()
        {
            var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64; rv:65.0) Gecko/20100101 Firefox/65.0");

            try
            {
                var html = await httpClient.GetAsync(url);
                string htmlStr;

                Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);

                using (var sr = new StreamReader(await html.Content.ReadAsStreamAsync(), Encoding.GetEncoding("UTF-8")))
                {
                    htmlStr = sr.ReadToEnd();
                }

                await SetMenuCache(htmlStr);
            }
            catch (Exception e)
            {

            }
        }

        protected abstract Task SetMenuCache(string htmlStr);
    }
}
