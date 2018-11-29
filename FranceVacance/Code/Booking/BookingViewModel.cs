using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using FranceVacance.Code.Accommodation;
using FranceVacance.Code.Common;

namespace FranceVacance.Code.Booking {
    public class BookingViewModel : ViewModelBase {

        private ObservableCollection<BookingModel> _bookings { get; set; }
        private BookingService _bookingService;

        public ObservableCollection<BookingModel> Bookings {
            get => _bookings;
            set {
                _bookings = value;
                OnPropertyChanged("Bookings");
            }
        }

        public async Task LoadData() {
            Bookings = await _bookingService.LoadDataAsync();
        }

        public async Task SaveData() {
            await _bookingService.SaveDataAsync(Bookings);
        }

        public BookingViewModel() {
            _bookingService = new BookingService();
            Bookings = new ObservableCollection<BookingModel>();
        }
    }
}