using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using FranceVacance.Code.Accommodation;
using FranceVacance.Code.Common;

namespace FranceVacance.Code.Search {
    public class SearchViewModel : ViewModelBase {
        private AccommodationViewModel _accommodationsFiltered { get; set; }

        public AccommodationViewModel AccommodationViewModel { get; set; }

        public SearchFiltersViewModel SearchAccommodation { get; set; }

        public Booking.BookingViewModel BookingViewModel { get; set; }

        public AccommodationViewModel AccommodationsFiltered {
            get { return _accommodationsFiltered; }
            set {
                _accommodationsFiltered = value;
            }
        }

        public async Task InitializeData() {
            await AccommodationViewModel.LoadData();
            await AccommodationsFiltered.LoadData();
            await BookingViewModel.LoadData();
            BookingViewModel.Bookings.First().Accommodation = AccommodationViewModel.Accommodations.First();
            BookingViewModel.Bookings.Last().Accommodation = AccommodationViewModel.Accommodations.Last();
            SearchAccommodation.MaxPrice = FindMaxPrice();
            SearchAccommodation.SelectedMaxPrice = SearchAccommodation.MaxPrice;
            Search(
                byName: false,
                byMaxPrice: true,
                byAddress: false,
                byDate: true
            );
            BookingViewModel.SaveData();
        }


        public SearchViewModel() {
            AccommodationViewModel = new AccommodationViewModel();
            AccommodationsFiltered = new AccommodationViewModel();
            SearchAccommodation = new SearchFiltersViewModel();
            BookingViewModel = new Booking.BookingViewModel();

            InitializeData();

            SearchAccommodation.CheckIn = DateTime.Today;
            SearchAccommodation.CheckOut = DateTime.Today.AddDays(1);
        }



        public AccommodationViewModel Search(
            bool byName = false, 
            bool byMaxPrice = false, 
            bool byAddress = false,
            bool byDate = false
        ) {

            if (String.IsNullOrWhiteSpace(SearchAccommodation.Name) && SearchAccommodation.MaxPrice < 1) {
                AccommodationsFiltered.Accommodations = AccommodationViewModel.Accommodations;
                OnPropertyChanged("AccommodationsFiltered");
            }

            ObservableCollection<Accommodation.AccommodationModel> filteredResults = 
                new ObservableCollection<Accommodation.AccommodationModel>();
            foreach (var _accommodation in AccommodationViewModel.Accommodations) {

                bool isNameMatch = false;
                bool isPriceMatch = false;
                bool isAddressMatch = false;
                List<bool> isDateMatch = new List<bool>();

                if ( !string.IsNullOrEmpty(SearchAccommodation.Name) && 
                    _accommodation.Name.ToLower().Contains(SearchAccommodation.Name.ToLower())
                )
                    isNameMatch = true;

                if (_accommodation.Price <= SearchAccommodation.SelectedMaxPrice)
                    isPriceMatch = true;

                if (!string.IsNullOrEmpty(SearchAccommodation.Address) &&
                    _accommodation.Address.ToLower().Contains(SearchAccommodation.Address.ToLower())
                )
                    isAddressMatch = true;

                foreach (var _booking in BookingViewModel.Bookings) {
                    //check if the current _accommodation has bookings
                    if (_accommodation == _booking.Accommodation) {
                        Debug.WriteLine($"booking checkin: {_booking.CheckIn} | booking checkout: {_booking.CheckOut}");
                        Debug.WriteLine($"searched checkin: {SearchAccommodation.CheckIn} | searched checkout: {SearchAccommodation.CheckOut}");
                        Debug.WriteLine("_______________________________");

                        // https://stackoverflow.com/a/13513973/1869192
                        //check if the accommodation DOESN'T have a booking in the searched date
                        if ((_booking.CheckIn < SearchAccommodation.CheckOut &&
                              SearchAccommodation.CheckIn < _booking.CheckOut) == false) {
                            isDateMatch.Add(true);
                        } else {
                            isDateMatch.Add(false);
                        }
                    }
                }

                if (byName == isNameMatch && 
                    byMaxPrice == isPriceMatch && 
                    byAddress == isAddressMatch &&
                    ((byDate == isDateMatch.TrueForAll(d => d == true)))
                    ) {
                    filteredResults.Add(_accommodation);
                }
            }

            AccommodationsFiltered.Accommodations = filteredResults;
            OnPropertyChanged("AccommodationsFiltered");

            return AccommodationsFiltered;
        }

        public double FindMaxPrice() {
            double maxPrice = 0;
            foreach (var _accommodation in AccommodationViewModel.Accommodations) {
                maxPrice = _accommodation.Price > maxPrice ? _accommodation.Price : maxPrice;
            }

            return maxPrice;
        }
    }
}
