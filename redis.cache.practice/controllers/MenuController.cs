using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using redis.cache.practice.services.crawler;
using redis.cache.practice.services.menuStore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace redis.cache.practice.Controllers
{
    [Route("api/menu")]
    public class MenuController : Controller
    {
        private IMenuStore menuStore;

        public MenuController(IMenuStore menuStore)
        {
            this.menuStore = menuStore;
        }

        [HttpGet("{restaurant_id}")]
        public async Task<IActionResult> GetMenu(string restaurant_id)
        {
            var menu = await menuStore.GetMenu(restaurant_id);
            return Ok();
        }
    }
}
