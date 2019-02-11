using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CoffeeShopApp2._0.Models
{
    public class WeeklyForecast
    {
        public WeeklyForecastData Data { get; set; }
    }

    public class WeeklyForecastData
    {
        public string[] Temperature { get; set; }
    }
}