using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FranceVacance.Helpers
{
    public class SearchAccommodationModel
    {
        public double SelectedMaxPrice { get; set; }
        public string Name { get; set; }
        public double MaxPrice { get; set; }
        public DateTime? CheckIn { get; set; }
        public DateTime? CheckOut { get; set; }

        public SearchAccommodationModel()
        {


            Name = "";
            CheckIn = null;
            CheckOut = null;

        }
    }
}
