using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using OrderingWebApp.Models;

namespace OrderingWebApp.Controllers
{
    public class HomeController : Controller
    {
        private IConfiguration _config { get; set; }

        public HomeController(IConfiguration config)
        {
            _config = config;
        }

        public IActionResult Index()
        {
            return View(new SearchViewModel());
        }

       public async Task<IActionResult> Search(SearchViewModel model)
        {
            string baseURL = _config.GetValue<string>("MySettings:baseURL");
            var requestUri = $"{baseURL}api/foodSearch?foodSearch={model.FoodItem}&location={model.Location}";
            using (var client = new HttpClient())
            using (var response = await client.GetAsync(requestUri))
            using (var content = response.Content)
            {
                string data = await content.ReadAsStringAsync();
                if (data == null)
                {
                    return View(new List<RestuarantViewModel>());
                }

                var matchingShops = JsonConvert.DeserializeObject<List<RestuarantViewModel>>(data);
                return View(matchingShops);
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
