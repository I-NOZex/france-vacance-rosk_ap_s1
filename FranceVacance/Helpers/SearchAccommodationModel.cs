using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FranceVacance.Helpers {
    public class SearchAccommodationModel {
        public double MaxPrice { get; set; }
        public string Name { get; set; }

        public SearchAccommodationModel() {
            MaxPrice = 0.0;
            Name = "";
        }
    }
}
