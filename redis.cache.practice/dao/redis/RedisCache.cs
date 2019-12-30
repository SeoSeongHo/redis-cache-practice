using StackExchange.Redis;
using System.Threading.Tasks;

namespace redis.cache.practice.services.redis
{
    public class RedisCache
    {
        private static RedisCache instance;
        private static readonly object padlock = new object();
        private IDatabase redisCache;

        public RedisCache()
        {
            var client = ConnectionMultiplexer.Connect("127.0.0.1:6379");
            redisCache = client.GetDatabase();
        }

        public static RedisCache Init
        {
            get
            {
                lock (padlock)
                {
                    if (instance == null)
                        instance = new RedisCache();

                    return instance;
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
