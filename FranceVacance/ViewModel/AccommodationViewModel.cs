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
            _accommodationCatalog = new AccommodationCatalog();
        }

        public List<AccommodationModel> Search(Dictionary<String, String> filters) {
            string name;
            filters.TryGetValue("name", out name);

            /*
            List <AccommodationModel> filteredResults = new List<AccommodationModel>();
            for (int i = 0; _accommodationCatalog.Accommodations.Count < i; i++) {
                if(_accommodationCatalog.Accommodations[i].Name == name)
                    filteredResults.Add(_accommodationCatalog.Accommodations[i]);
            }
            */
            return (List<AccommodationModel>)_accommodationCatalog.Accommodations.Where(
                obj => obj.Name == name
            );
        }



        public int sum(int num1, int num2) {
            return num1 + num2;
        }
    }
}
