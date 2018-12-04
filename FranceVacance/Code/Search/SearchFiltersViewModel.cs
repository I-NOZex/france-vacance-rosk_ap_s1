using System;
using FranceVacance.Code.Common;

namespace FranceVacance.Code.Search {
    public class SearchFiltersViewModel : ViewModelBase {
        private double _selectedMaxPrice { get; set; }
        private string _name { get; set; }
        private string _address { get; set; }
        private double _maxPrice { get; set; }
        private DateTimeOffset? _checkIn { get; set; }
        private DateTimeOffset? _checkOut { get; set; }

        public double SelectedMaxPrice {
            get => _selectedMaxPrice;
            set {
                _selectedMaxPrice = value;
                OnPropertyChanged("SelectedMaxPrice");
            }
        }

        public string Name {
            get => _name;
            set {
                _name = value;
                OnPropertyChanged("Name");
            }
        }
        public string Address {
            get => _address;
            set {
                _address = value;
                OnPropertyChanged("Address");
            }
        }
        public double MaxPrice {
            get => _maxPrice;
            set {
                _maxPrice = value;
                OnPropertyChanged("MaxPrice");
            }
        }
        public DateTimeOffset? CheckIn {
            get => _checkIn;
            set {
                _checkIn = value;
                OnPropertyChanged("CheckIn");
            }
        }
        public DateTimeOffset? CheckOut {
            get => _checkOut;
            set {
                _checkOut = value;
                OnPropertyChanged("CheckOut");
            }
        }

        public SearchFiltersViewModel() {
            Reset();
        }

        public void Reset() {
            Name = "";
            Address = "";
            CheckIn = DateTimeOffset.Now;
            CheckOut = DateTimeOffset.Now.AddDays(1);
            SelectedMaxPrice = MaxPrice;
        }
    }
}
