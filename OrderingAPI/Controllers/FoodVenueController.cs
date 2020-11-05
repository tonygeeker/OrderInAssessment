using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using OrderingAPI.Models;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace OrderingAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FoodVenueController : ControllerBase
    {
        private readonly IConfiguration _config;

        public FoodVenueController(IConfiguration config)
        {
            _config = config;
        }
        // GET api/values
        [HttpGet]
        public ActionResult<List<FoodSearchResult>> Get(string foodSearch, string location)
        {
            bool isInputTextFile = _config.GetValue<bool>("MySettings:IsInputTextFile");
            var foodSearchResults = new List<FoodSearchResult>();

            if (isInputTextFile)
            {
                //string filePath = _config.GetValue<string>("MySettings:FilePath");
                var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "SampleData.json.js");

                foodSearchResults = SearchMenuItemsFromJsonFile(foodSearch, location, filePath);
            }
            // for a database input data set, an else statement making use of a connection string 
            // from appSettings with code for retrieving data, would go here

            return foodSearchResults;
        }

        private List<FoodSearchResult> SearchMenuItemsFromJsonFile(string foodSearch, string location, string filePath)
        {
            string jsonFile = "";
            if (System.IO.File.Exists(filePath))
            {
                jsonFile = System.IO.File.ReadAllText(filePath);
            }
            else
            {
                return new List<FoodSearchResult>();
            }

            var venuesInTextFile = JsonConvert.DeserializeObject<List<FoodVenue>>(jsonFile);
            if (venuesInTextFile == null)
            {
                return new List<FoodSearchResult>();
            }

            var foodSearchResults = new List<FoodSearchResult>();

            foreach (var venue in venuesInTextFile)
            {
                if (venue.Suburb.ToLower() == location.ToLower() || venue.Name.ToLower().Contains(location.ToLower()) ||
                        venue.City.ToLower() == location.ToLower())
                {
                    foreach (var category in venue.Categories)
                    {
                        var menuItems = category.MenuItems.Where(x => x.Name.ToLower().Contains(foodSearch.ToLower())).ToList();
                        if (menuItems.Count > 0)
                        {
                            foodSearchResults.Add(new FoodSearchResult
                            {
                                RestuarantName = venue.Name,
                                LogoPath = venue.LogoPath,
                                Suburb = venue.Suburb,
                                Rank = venue.Rank,
                                MenuItemsCount = menuItems.Count,
                                MenuItems = menuItems,
                                ItemsInCategoryCount = category.Name.ToLower().Contains(foodSearch.ToLower())
                                                        ? category.MenuItems.Count
                                                        : 0
                            });
                        }
                        else if (category.Name.ToLower().Contains(foodSearch.ToLower()))
                        {
                            foodSearchResults.Add(new FoodSearchResult
                            {
                                RestuarantName = venue.Name,
                                LogoPath = venue.LogoPath,
                                Suburb = venue.Suburb,
                                Rank = venue.Rank,
                                MenuItemsCount = category.MenuItems.Count(),
                                MenuItems = category.MenuItems,
                                ItemsInCategoryCount = category.MenuItems.Count
                            });
                        }
                    }
                }
            }
            return foodSearchResults;
        }

        [HttpPost]
        public OrderResponse PlaceOrder(Order order)
        {
            return new OrderResponse
            {
                FoodItem = order.MenuItem.Name,
                IsSuccess = true,
                RestaurantName = order.RestaurantName,
                ShopLocation = order.Suburb
            };
        }
    }
}
