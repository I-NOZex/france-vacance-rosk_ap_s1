using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Globalization.NumberFormatting;
using FranceVacance.Data;
using FranceVacance.Helpers;
using FranceVacance.Model;
namespace FranceVacance.ViewModel {
    public class AccommodationViewModel : ViewModelBase {
        private AccommodationCatalog _accommodationCatalog { get; set; }
        private AccommodationCatalog _accommodationCatalogFiltered { get; set; }

        public SearchAccommodationModel SearchAccommodation { get; set; }

        public AccommodationCatalog AccommodationCatalog {
            get { return _accommodationCatalog; }
            set {
                _accommodationCatalog = value;
            }
        }

        public AccommodationCatalog AccommodationCatalogFiltered {
            get { return _accommodationCatalogFiltered; }
            set {
                _accommodationCatalogFiltered = value;
            }
        }
        public AccommodationViewModel() {
            AccommodationCatalog = new AccommodationCatalog();
            AccommodationCatalogFiltered = new AccommodationCatalog();
            SearchAccommodation = new SearchAccommodationModel();


        }

        public void Search() {

            if (String.IsNullOrWhiteSpace(SearchAccommodation.Name) && SearchAccommodation.MaxPrice < 1) {
                AccommodationCatalogFiltered.Accommodations = AccommodationCatalog.Accommodations;
                OnPropertyChanged("AccommodationCatalogFiltered");
            }

            ObservableCollection<AccommodationModel> filteredResults = new ObservableCollection<AccommodationModel>();
            foreach (var _accommodation in _accommodationCatalog.Accommodations) {
                if(_accommodation.Name.Contains(SearchAccommodation.Name) && _accommodation.Price <= SearchAccommodation.MaxPrice)
                    filteredResults.Add(_accommodation);
            }

            /*return (List<AccommodationModel>)_accommodationCatalog.Accommodations.Where(
                _accommodation => _accommodation.Name == name
            );*/

            AccommodationCatalogFiltered.Accommodations = filteredResults;
            OnPropertyChanged("AccommodationCatalogFiltered");
        }



        public int sum(int num1, int num2) {
            return num1 + num2;
        }
    }
}
