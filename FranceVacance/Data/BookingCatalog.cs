using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.ApplicationModel.Appointments.AppointmentsProvider;

namespace FranceVacance.Data {
    public class BookingCatalog

    {
        public ObservableCollection<BookingModel> Bookings;

        public BookingCatalog()
        {
            Bookings = new ObservableCollection<BookingModel>();


    }
}
