using StackExchange.Redis;
using System;
using System.Threading.Tasks;

namespace redis.cache.practice.services.redis
{
    public sealed class RedisCache
    {
        private static RedisCache _instance = null;
        private static readonly object padlock = new object();
        private IDatabase redisCache;

        public RedisCache()
        {
            var option = new ConfigurationOptions
            {
                AbortOnConnectFail = false,
                EndPoints = { "localhost:6379" }
            };
            var client = ConnectionMultiplexer.Connect(option);
            redisCache = client.GetDatabase();
        }

        public static RedisCache Instance
        {
            get
            {
                lock (padlock)
                {
                    if (_instance == null)
                        _instance = new RedisCache();

                    return _instance;
                }
            }
            
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
