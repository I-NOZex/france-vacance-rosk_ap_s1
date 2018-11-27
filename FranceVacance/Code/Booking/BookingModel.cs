using System;
using Newtonsoft.Json;

namespace FranceVacance.Code.Booking {

    public class BookingModel
    {
        private int _id;
        private double _totalPrice;
        private DateTime _checkIn;
        private DateTime _checkOut;
        private Accommodation.AccommodationModel _accommodation;

        public int Id { get; set; }
        public double TotalPrice { get; set; }
        public DateTime CheckIn { get; set; }
        public DateTime CheckOut { get; set; }

        [JsonProperty(IsReference = true)]
        public Accommodation.AccommodationModel Accommodation { get; set; }

    }
}
