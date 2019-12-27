using redis.cache.practice.dao.redis;
using redis.cache.practice.models;
using redis.cache.practice.services.redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace redis.cache.practice.services.menuStore
{
    public class MenuStore
    {
        private IRedisCache redisCache;

        public MenuStore(IRedisCache redisCache)
        {
            this.redisCache = redisCache;
        }

        public async Task<FoodMenu> GetMenu(string restaurant)
        {
            var menus = await redisCache.HashGetAll(restaurant);

            if (menus.Count() == 0)
            {
                // TODO 크롤링
            }

            else
            {
                return new FoodMenu
                {
                    restaurant = restaurant,
                    food = new Food
                    {
                        breakfast = menus.FirstOrDefault(x => x.Name == "breakfast").ToString(),
                        lunch = menus.FirstOrDefault(x => x.Name == "lunch").ToString(),
                        dinner = menus.FirstOrDefault(x => x.Name == "dinner").ToString()
                    }
                };
            }
        }

        public async Task<List<FoodMenu>> GetMenus()
        {

        }
    }
}
