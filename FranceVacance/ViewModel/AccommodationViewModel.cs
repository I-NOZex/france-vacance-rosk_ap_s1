using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Globalization.NumberFormatting;
using FranceVacance.Data;
using FranceVacance.Model;

namespace FranceVacance.ViewModel {
    class AccommodationViewModel {
        private AccommodationCatalog _accommodationCatalog;
        public AccommodationViewModel() {
            var filters = new Dictionary<string, string>()

        }

        public List<AccommodationModel> Search(Dictionary<String, String> filters) {
            string name;
            filters.TryGetValue("name", out name);

            
            List <AccommodationModel> filteredResults = new List<AccommodationModel>();
            foreach (var _accommodation in _accommodationCatalog.Accommodations) {
                if(_accommodation.Name == name)
                    filteredResults.Add(_accommodation);
            }

            /*return (List<AccommodationModel>)_accommodationCatalog.Accommodations.Where(
                _accommodation => _accommodation.Name == name
            );*/

            return filteredResults;
        }



        public int sum(int num1, int num2) {
            return num1 + num2;
        }
    }
}
