namespace redis.cache.practice.models
{
    public class FoodMenu
    {
        public string restaurant { get; set; }
        public Food food { get; set; }

        public string ToBreif(string fullName)
        {
            switch (fullName)
            {
                case "학생회관식당(880-5543)":
                default:
                    return "0";
                case "자하연식당(880-7888)":
                    return "1";
                case "예술계식당(876-1006)":
                    return "2";
                case "소담마루(880-8698)":
                    return "3";
                case "샤반(871-6933)":
                    return "4";
                case "라운지오(882-7005)":
                    return "5";
                case "두레미담(880-9358)":
                    return "6";
                case "동원관식당(880-8697)":
                    return "7";
                case "기숙사식당(881-9072)":
                    return "8";
                case "공대간이식당(889-8956)":
                    return "9";
                case "감골식당(880-5544)":
                    return "10";
                case "4식당(889-6946)":
                    return "11";
                case "3식당(880-5545)":
                    return "12";
                case "302동식당(880-1939)":
                    return "13";
                case "301동식당(889-8955)":
                    return "14";
                case "220동식당(875-0240)":
                    return "15";
            }
        }
    }

    public class Food
    {
        public string breakfast { get; set; }
        public string lunch { get; set; }
        public string dinner { get; set; }
    }
}
