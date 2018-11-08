using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.ApplicationModel.Appointments.AppointmentsProvider;

namespace FranceVacance.Data {
    public class BookingCatalog

    {
        public List<BookingModel> Bookings;

        public BookingCatalog()
        {
            Bookings = new List<BookingModel>();
            BookingModel One = new BookingModel();
            One.TotalPrice = 999.99;
            One.CheckIn = DateTime.Today;
            One.CheckOut = DateTime.Today.AddDays(1);

            Bookings.Add(One);


        }
    }
}
