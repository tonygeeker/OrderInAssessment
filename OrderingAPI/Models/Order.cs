using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrderingAPI.Models
{
    public class Order
    {
        public int RestaurantId { get; set; }
        public string RestaurantName { get; set; }
        public string Suburb { get; set; }
        public int Rank { get; set; }
        public MenuItem MenuItem { get; set; }
        public OrderStatus StatusOfOrder { get; set; }
    }

    public class OrderResponse
    {
        public string RestaurantName { get; set; }
        public string ShopLocation { get; set; }
        public string FoodItem { get; set; }
        public bool IsSuccess { get; set; }
    }
}

