using redis.cache.practice.models;
using System.Threading.Tasks;

namespace redis.cache.practice.services.menuStore
{
    public interface IMenuStore
    {
        Task<FoodMenu> GetMenu(string restaurant);
    }
}
