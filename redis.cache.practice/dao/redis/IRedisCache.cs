using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace redis.cache.practice.dao.redis
{
    public interface IRedisCache
    {
        Task<string> Get(string id);
        Task Set(string key, string value);
        Task<string> HashGet(params string[] keys);
        Task<HashEntry[]> HashGetAll(string key);
        Task HashSet(string key, HashEntry[] value);
    }
}
