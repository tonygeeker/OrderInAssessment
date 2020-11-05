using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrderingWebApp.Models
{
    public class OrderItem
    {
        public int RestaurantId { get; set; }
        public string RestuarantName { get; set; }
        public string Suburb { get; set; }
        public int Rank { get; set; }
        public MenuItemViewModel MenuItem { get; set; }
    }

    public class OrderResponse
    {
        public string RestaurantName { get; set; }
        public string ShopLocation { get; set; }
        public string FoodItem { get; set; }
        public bool IsSuccess { get; set; }
    }
}
