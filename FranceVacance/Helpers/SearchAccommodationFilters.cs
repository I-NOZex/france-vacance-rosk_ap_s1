﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FranceVacance.Helpers
{
    public class SearchAccommodationFilters
    {
        public double SelectedMaxPrice { get; set; }
        public string Name { get; set; }
        public double MaxPrice { get; set; }
        public DateTime? CheckIn { get; set; }
        public DateTime? CheckOut { get; set; }

        public SearchAccommodationFilters()
        {


            Name = "";
            CheckIn = null;
            CheckOut = null;

        }
    }
}