using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
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

        [HttpPost]
        public async Task<IActionResult> GetMenu([FromBody] Dictionary<string, string> restaurant)
        {
            return Json(new { data = await menuStore.GetMenu(restaurant["restaurant_id"]) } );
        }
    }
}
