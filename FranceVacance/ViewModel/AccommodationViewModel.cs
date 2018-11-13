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
        private AccommodationCatalog _accommodationCatalogFiltered { get; set; }

        private AccommodationCatalog _accommodationCatalog { get; set; }
        public AccommodationCatalog AccommodationCatalog {
            get { return _accommodationCatalog; }
            set {
                _accommodationCatalog = value;
            }
        }

        private SearchAccommodationModel _searchAccommodation { get; set; }
        public SearchAccommodationModel SearchAccommodation {
            get => _searchAccommodation;
            set => _searchAccommodation = value;
        }

        private BookingCatalog _bookingCatalog { get; set; }
        public BookingCatalog BookingCatalog {
            get => _bookingCatalog;
            set => _bookingCatalog = value;
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
            BookingCatalog BookingCatalog = new BookingCatalog();

            BookingModel One = new BookingModel();

            One.TotalPrice = 999.99;
            One.CheckIn = DateTime.Today;
            One.CheckOut = DateTime.Today.AddDays(1);

            BookingCatalog.Bookings.Add(One);

            BookingModel One1 = new BookingModel();
            One1.TotalPrice = 999.8899;
            One1.CheckIn = DateTime.Today;
            One1.CheckOut = DateTime.Today.AddDays(1);
            BookingCatalog.Bookings.Add(One1);
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


                foreach (var _booking in _bookingCatalog.Bookings) {
                    //check if the current _accommodation has bookings
                    if (_accommodation == _booking.Accommodation) {
                        //check for date collision 

                        if (!(_booking.CheckIn < SearchAccommodation.CheckOut &&
                              SearchAccommodation.CheckIn < _booking.CheckOut)) {

                        }

                    }
                }
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
