using System;
using FranceVacance.Code.Accommodation;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace FranceVacance.Code.Booking {

    [JsonConverter(typeof(BookingModelConverter))]
    public class BookingModel
    {
        private int _id { get; set; }
        private double _totalPrice { get; set; }
        private DateTime _checkIn { get; set; }
        private DateTime _checkOut { get; set; }
        private AccommodationModel _accommodation { get; set; }

        public int Id { get => _id; set => _id = value; }
        public double TotalPrice { get => _totalPrice; set => _totalPrice = value; }
        public DateTime CheckIn { get => _checkIn; set => _checkIn = value; }
        public DateTime CheckOut { get => _checkOut; set => _checkOut = value; }

        public AccommodationModel Accommodation { get => _accommodation; set => _accommodation = value; }

    }
}
