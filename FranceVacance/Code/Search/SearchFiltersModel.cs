using System;

namespace FranceVacance.Code.Search
{
    public class SearchFiltersModel {
        public double SelectedMaxPrice { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public double MaxPrice { get; set; }
        public DateTimeOffset? CheckIn { get; set; }
        public DateTimeOffset? CheckOut { get; set; }

        public SearchFiltersModel()
        {
            Name = "";
            Address = "";
            CheckIn = null;
            CheckOut = null;
        }
    }
}
