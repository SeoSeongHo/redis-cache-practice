using redis.cache.practice.dao.redis;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace redis.cache.practice.services.redis
{
    public class RedisCache : IRedisCache
    {
        private static IDatabase redisCache;

        public RedisCache()
        {
            var client = ConnectionMultiplexer.Connect("localhost");
            redisCache = client.GetDatabase();
        }

        public async Task<string> Get(string key)
        {
            return await redisCache.StringGetAsync(key);
        }

        public async Task<string> HashGet(params string[] keys)
        {
            return await redisCache.HashGetAsync(keys[0], keys[1]);
        }

        public async Task<HashEntry[]> HashGetAll(string key)
        {
            return await redisCache.HashGetAllAsync(key);
        }

        public async Task Set(string key, string value)
        {
            await redisCache.StringSetAsync(key, value);
        }

        public async Task HashSet(string key, HashEntry[] value)
        {
            await redisCache.HashSetAsync(key, value);
        }
    }
}
