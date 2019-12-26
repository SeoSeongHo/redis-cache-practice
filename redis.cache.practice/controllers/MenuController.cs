using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace redis.cache.practice.Controllers
{
    [Route("api/menu")]
    public class MenuController : Controller
    {
        [HttpGet]
        public IActionResult GetMenus()
        {
            // return menu list
            return Ok();
        }

        [HttpGet("{shop_id}")]
        public IActionResult GetMenu(string shop_id)
        {
            // return menu
            return Ok();
        }
    }
}
