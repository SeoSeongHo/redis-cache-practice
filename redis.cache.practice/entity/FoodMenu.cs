using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace redis.cache.practice.models
{
    public class FoodMenu
    {
        public string restaurant { get; set; }
        public Food food { get; set; }
    }

    public class Food
    {
        public string breakfast { get; set; }
        public string lunch { get; set; }
        public string dinner { get; set; }
    }
}
