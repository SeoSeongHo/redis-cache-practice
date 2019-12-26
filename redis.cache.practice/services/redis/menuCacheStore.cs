using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace redis.cache.practice.services.redis
{
    public class menuCacheStore
    {
        public string GetMenus()
        {
            var client = ConnectionMultiplexer.Connect("localhost");
            var database = client.GetDatabase();

            // do process

            return "";
        }
    }
}
