using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrderingWebApp.Models
{
    public class OrderItem
    {
        public string RestuarantName { get; set; }
        public string Suburb { get; set; }
        public int Rank { get; set; }
        public MenuItemViewModel MenuItem { get; set; }
    }
}
