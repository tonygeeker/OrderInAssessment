﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrderingAPI.Models
{
    public class FoodVenue
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public string Suburb { get; set; }
        public string LogoPath { get; set; }
        public int Rank { get; set; }
        public List<Category> Categories { get; set; }
    }
}
