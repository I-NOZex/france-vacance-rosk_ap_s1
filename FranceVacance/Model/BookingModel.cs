using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FranceVacance.Model;

namespace FranceVacance.Data {

    public class BookingModel
    {
        private int _id;
        private double _totalPrice;
        private DateTime _checkIn;
        private DateTime _checkOut;
        private AccommodationModel _accommodation;

        public int Id { get; set; }
        public double TotalPrice { get; set; }
        public DateTime CheckIn { get; set; }
        public DateTime CheckOut { get; set; }
        public AccommodationModel Accommodation { get; set; }

    }
}
