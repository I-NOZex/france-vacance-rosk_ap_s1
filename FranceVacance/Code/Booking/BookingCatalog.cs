using System.Collections.ObjectModel;

namespace FranceVacance.Code.Booking {
    public class BookingCatalog

    {
        public ObservableCollection<BookingModel> Bookings;

        public BookingCatalog() {
            Bookings = new ObservableCollection<BookingModel>();


        }
    }
}
