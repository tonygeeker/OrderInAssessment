using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OrderingWebApp.Models
{
    public class RestuarantViewModel
    {   
        [DisplayName("Restuarant Name")]
        public string RestuarantName { get; set; }
        public string Suburb { get; set; }
        public int Rank { get; set; }
        public int MenuItemsCount { get; set; }
        public string LogoPath { get; set; }
        public int ItemsInCategoryCount { get; set; }
        public List<MenuItemViewModel> MenuItems { get; set; }
    }
}
