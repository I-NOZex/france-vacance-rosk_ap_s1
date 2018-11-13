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

            BookingModel One = new BookingModel();
           
            One.TotalPrice = 999.99;
            One.CheckIn = DateTime.Today;
            One.CheckOut = DateTime.Today.AddDays(1);
            
            Bookings.Add(One);

 BookingModel One1 = new BookingModel();
            One1.TotalPrice = 999.8899;
            One1.CheckIn = DateTime.Today;
            One1.CheckOut = DateTime.Today.AddDays(1);
            Bookings.Add(One1);
        }
    }
}
