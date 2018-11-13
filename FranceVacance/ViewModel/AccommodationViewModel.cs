using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
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

        public AccommodationCatalog AccommodationCatalog { get; set; }

        public SearchAccommodationFilters SearchAccommodation { get; set; }

        public BookingCatalog BookingCatalog { get; set; }
        public AccommodationCatalog AccommodationCatalogFiltered {
            get { return _accommodationCatalogFiltered; }
            set {
                _accommodationCatalogFiltered = value;
            }
        }
        public AccommodationViewModel() {
            AccommodationCatalog = new AccommodationCatalog();
            AccommodationCatalogFiltered = new AccommodationCatalog();
            SearchAccommodation = new SearchAccommodationFilters();
            BookingCatalog = new BookingCatalog();

            BookingModel One = new BookingModel();

            One.TotalPrice = 999.99;
            One.CheckIn = DateTime.Today;
            One.CheckOut = DateTime.Today.AddDays(1);
            One.Accommodation = AccommodationCatalog.Accommodations.First();
            BookingCatalog.Bookings.Add(One);

            BookingModel One1 = new BookingModel();
            One1.TotalPrice = 999.8899;
            One1.CheckIn = DateTime.Today.AddDays(2); ;
            One1.CheckOut = DateTime.Today.AddDays(3);
            One1.Accommodation = AccommodationCatalog.Accommodations.Last();
            BookingCatalog.Bookings.Add(One1);

            SearchAccommodation.CheckIn = DateTime.Today;
            SearchAccommodation.CheckOut = DateTime.Today.AddDays(1);
            SearchAccommodation.MaxPrice = FindMaxPrice();
            SearchAccommodation.SelectedMaxPrice = SearchAccommodation.MaxPrice;
        }



        public void Search() {

            if (String.IsNullOrWhiteSpace(SearchAccommodation.Name) && SearchAccommodation.MaxPrice < 1) {
                AccommodationCatalogFiltered.Accommodations = AccommodationCatalog.Accommodations;
                OnPropertyChanged("AccommodationCatalogFiltered");
            }

            ObservableCollection<AccommodationModel> filteredResults = new ObservableCollection<AccommodationModel>();
            foreach (var _accommodation in AccommodationCatalog.Accommodations) {
                bool isMatch = false;
                if (_accommodation.Name.Contains(SearchAccommodation.Name) &&
                    _accommodation.Price <= SearchAccommodation.SelectedMaxPrice)
                    isMatch = true;


                foreach (var _booking in BookingCatalog.Bookings) {
                    //check if the current _accommodation has bookings
                    if (_accommodation == _booking.Accommodation) {
                        Debug.WriteLine($"booking checkin: {_booking.CheckIn} | booking checkout: {_booking.CheckOut}");
                        Debug.WriteLine($"searched checkin: {SearchAccommodation.CheckIn} | searched checkout: {SearchAccommodation.CheckOut}");
                        Debug.WriteLine("_______________________________");

                        // https://stackoverflow.com/a/13513973/1869192
                        //check if the accommodation DOESN'T have a booking in the searched date
                        if ((_booking.CheckIn < SearchAccommodation.CheckOut &&
                              SearchAccommodation.CheckIn < _booking.CheckOut) == false) {
                            isMatch = true;
                        }
                        else {
                            isMatch = false;
                        }

                    }
                }

                if (isMatch) {
                    filteredResults.Add(_accommodation);
                }
            }

            AccommodationCatalogFiltered.Accommodations = filteredResults;
            OnPropertyChanged("AccommodationCatalogFiltered");
        }

        public double FindMaxPrice() {
            double maxPrice = 0;
            foreach (var _accommodation in AccommodationCatalog.Accommodations) {
                maxPrice = _accommodation.Price > maxPrice ? _accommodation.Price : maxPrice;
            }

            return maxPrice;
        }
    }
}
