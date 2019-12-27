using HtmlAgilityPack;
using redis.cache.practice.models;
using redis.cache.practice.services.redis;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace redis.cache.practice.services.crawler
{
    public class MenuCrawler : BaseCrawler
    {
        public MenuCrawler(string url, RedisCache redisCache) : base (url, redisCache)
        {

        }

        protected override async Task SetMenuCache(string htmlStr)
        {
            var htmlDocument = new HtmlDocument();
            htmlDocument.LoadHtml(htmlStr);

            var restaurants = GetFoodMenu(htmlDocument, "restaurant");
            var breakfasts = GetFoodMenu(htmlDocument, "breakfast");
            var lunchs = GetFoodMenu(htmlDocument, "lunch");
            var dinners = GetFoodMenu(htmlDocument, "dinner");

            for (int i = 0; i < restaurants.Count; i++)
            {
                await SetMenus(new FoodMenu { 
                    restaurant = restaurants[i].InnerHtml,
                    food = new Food
                    {
                        breakfast = breakfasts[i].InnerHtml,
                        lunch = lunchs[i].InnerHtml,
                        dinner = dinners[i].InnerHtml
                    }
                });
            }
        }

        private HtmlNodeCollection GetFoodMenu(HtmlDocument htmlDocument, string foodType)
        {
            return htmlDocument.DocumentNode.SelectNodes($"//td[@class='views-field views-field-field-{foodType}']");
        }

        private async Task SetMenus(FoodMenu foodMenu)
        {
            await redisCache.HashSet(foodMenu.restaurant, new [] { new HashEntry("breakfast", foodMenu.food.breakfast), new HashEntry("lunch", foodMenu.food.lunch), new HashEntry("dinner", foodMenu.food.dinner) });
        }
    }
}
