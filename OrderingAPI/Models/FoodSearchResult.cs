using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrderingAPI.Models
{
    public class FoodSearchResult
    {
        public string RestuarantName { get; set; }
        public string Suburb { get; set; }
        public int Rank { get; set; }
        public int MenuItemsCount { get; set; }
        public int ItemsInCategoryCount { get; set; }
        public List<MenuItem> MenuItems { get; set; }
    }
}
