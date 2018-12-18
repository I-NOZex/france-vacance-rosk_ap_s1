using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Windows.Storage;
using Windows.UI.Xaml.Media.Imaging;
using FranceVacance.Code.Common;
using FranceVacance.Code.Helpers;
using FranceVacance.Code.User;

namespace FranceVacance.Code.Accommodation {
    public class AddAccommodationViewModel : ViewModelBase {
        private string _name { get; set; }
        private double _price { get; set; }
        private string _address { get; set; }
        private string _photo { get; set; }

        private string _nameError { get; set; }
        private string _priceError { get; set; }
        private string _addressError { get; set; }
        private string _photoError { get; set; }

        private AccommodationService _accommodationService;
        private ObservableCollection<AccommodationModel> _accommodationModelList { get; set; }
        public RelayCommand CreateAccommodation { get; set; }
        public string NameError {
            get => _nameError;
            set {
                _nameError = value;
                OnPropertyChanged("NameError");
            }
        }
        public string PriceError {
            get => _priceError;
            set {
                _priceError = value;
                OnPropertyChanged("PriceError");
            }
        }
        public string AddressError {
            get => _addressError;
            set {
                _addressError = value;
                OnPropertyChanged("AddressError");
            }
        }
        public string PhotoError {
            get => _photoError;
            set {
                _photoError = value;
                OnPropertyChanged("PhotoError");
            }
        }

        public string Name {
            get { return _name; }
            set {
                _name = value;
                OnPropertyChanged("Name");
            }
        }

        public double Price {
            get { return _price; }
            set {
                _price = value;
                OnPropertyChanged("Price");
            }
        }

        public string Address {
            get { return _address; }
            set {
                _address = value;
                OnPropertyChanged("Address");
            }
        }

        public string Photo {
            get { return _photo; }
            set {
                _photo = value;
                OnPropertyChanged("Photo");
            }
        }

        public ObservableCollection<AccommodationModel> AccommodationModelList {
            get => _accommodationModelList;
            set {
                _accommodationModelList = value;
                OnPropertyChanged("AccommodationModelList");
            }
        }



        public AddAccommodationViewModel() {
            AccommodationModelList = new ObservableCollection<AccommodationModel>();
            CreateAccommodation = new RelayCommand(o => AddAccommodation());
            _accommodationService = new AccommodationService();
            LoadData();

        }
        public async Task LoadData(bool force = false) {
            if (AccommodationModelList == null || AccommodationModelList.Count == 0 || force)
                AccommodationModelList = await _accommodationService.LoadDataAsync();

        }
        public async Task SaveData() {
            await _accommodationService.SaveDataAsync(AccommodationModelList);
        }

        public bool DoubleValidator(string input) {
            string pattern = "^[0-9]+(\\.[0-9]+)?$";
            if (Regex.IsMatch(input, pattern)) {
                return true;

            }

            return false;
        }

        private bool validate() {
            //Warning message is displayed if price is not numbers (0 - 9)
            //Warning message is displayed if any field is empty
            NameError = "";
            PriceError = "";
            AddressError = "";
            PhotoError = "";

            bool isValid = true;

            if (string.IsNullOrWhiteSpace(Name)) {
                NameError = "Name is required.";
                isValid = false;
            }

            if (Price <= 0.0) {
                PriceError = "Price is required.";
                isValid = false;
            }

            if (string.IsNullOrWhiteSpace(Address)) {
                AddressError = "Address is required.";
                isValid = false;
            }

            if (string.IsNullOrWhiteSpace(Photo)) {
                PhotoError = "Photo is required.";
                isValid = false;
            }

            if (!DoubleValidator(Price.ToString())) {
                PriceError = "Price isn't valid value. Eg: 999.99";
                isValid = false;
            }

            return isValid;
        }

        public async Task<bool> AddAccommodation() {

            if (validate()) {
                AccommodationModel newAccommodation = new AccommodationModel();
                newAccommodation.Price = Price;
                newAccommodation.Address = Address;
                newAccommodation.Name = Name;
                newAccommodation.Id = AccommodationModelList.Count + 1;

                StorageFile file = await StorageFile.GetFileFromPathAsync(Photo);
                StorageFile destFile = await file.CopyAsync(ApplicationData.Current.LocalFolder, file.Name, NameCollisionOption.GenerateUniqueName);
                newAccommodation.Photo = $"ms-appdata:///local/{destFile.Name}";

                AccommodationModelList.Add(newAccommodation);
                await SaveData();

                Name = "";
                Price = 0;
                Address = "";
                Photo = "";

                return true;
            }

            return false;
        }
    }
}
