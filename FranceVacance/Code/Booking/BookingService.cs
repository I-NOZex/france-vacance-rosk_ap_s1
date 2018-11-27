using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FranceVacance.Code.Accommodation;
using FranceVacance.Code.Helpers;

namespace FranceVacance.Code.Booking {
    public class BookingService : FileService<BookingModel> {
        private const string FILE_NAME = "bookings.json";

        public async Task<ObservableCollection<BookingModel>> LoadDataAsync() {
            return await LoadData(FILE_NAME);
        }

        public async Task<bool> SaveDataAsync(ObservableCollection<BookingModel> accommodationCollection) {
            return await SaveData(FILE_NAME, accommodationCollection);
        }
    }
}
