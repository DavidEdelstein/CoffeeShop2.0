using CoffeeShopApp2._0.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace CoffeeShopApp2._0.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index(string lat = "", string lon= "")
        {
            if (!string.IsNullOrEmpty(lat) && !string.IsNullOrEmpty(lon))
            {
                using (var client = new HttpClient())
                {
                    client.DefaultRequestHeaders.UserAgent.ParseAdd("Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/71.0.3578.98 Safari/537.36");
                    var jsonString = client.GetStringAsync($"https://forecast.weather.gov/MapClick.php?lat={lat}&lon={lon}&FcstType=json").ConfigureAwait(false).GetAwaiter().GetResult();
                    var model = JsonConvert.DeserializeObject<WeeklyForecast>(jsonString);
                    return View(model);
                }
            }

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}