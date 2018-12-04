using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FranceVacance.Code.Accommodation;
using FranceVacance.Code.Booking;
using FranceVacance.Code.Search;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests {
    [TestClass]
    public class FileServiceTest {
        private ObservableCollection<AccommodationModel> GenerateAccommodationCollection(int quantity) {
            ObservableCollection<AccommodationModel> Accommodations;
            Accommodations = new ObservableCollection<AccommodationModel>();
            Random r = new Random();
            List<string> addresses = new List<string>() {
                "Paris",
                "Nice",
                "Lion",
                "Cannes",
                "Montpellier",
                "Perpignan",
                "Prades",
                "Villefranche"
            };

            foreach (var idx in Enumerable.Range(0, quantity)) {
                Accommodations.Add(
                    new AccommodationModel() {
                        Id = idx,
                        Address = addresses.ElementAt(r.Next(addresses.Count - 1)),
                        Name = $"Demo accommodation #{idx}",
                        NumberOfRooms = r.Next(1, 8),
                        Price = Math.Pow(3, idx),
                        Rating = r.Next(0, 5),
                    }
                );
            }

            return Accommodations;

        }

        private ObservableCollection<BookingModel> GenerateBookingCollection(int quantity) {
            ObservableCollection<BookingModel> Bookings = new ObservableCollection<BookingModel>();

            foreach (var idx in Enumerable.Range(0, quantity)) {
                Bookings.Add(
                    new BookingModel() {
                        Id = idx,
                        CheckIn = DateTime.Today.AddDays(idx),
                        CheckOut = DateTime.Today.AddDays(idx+1),
                    }
                );
            }

            return Bookings;
        }


        [TestMethod]
        public async Task Save_BookingModel() {
            BookingService _bookingService = new BookingService();

            //generate 10 accommodations
            ObservableCollection<AccommodationModel> Accommodations = GenerateAccommodationCollection(10);

            //generate 4 bookings
            ObservableCollection<BookingModel> Bookings = GenerateBookingCollection(4);

            Bookings.ElementAt(0).Accommodation = Accommodations.ElementAt(2);
            Bookings.ElementAt(1).Accommodation = Accommodations.ElementAt(4);
            Bookings.ElementAt(2).Accommodation = Accommodations.ElementAt(6);
            Bookings.ElementAt(3).Accommodation = Accommodations.ElementAt(9);

            //save to file
            await _bookingService.SaveDataAsync(Bookings);
            //load file
            ObservableCollection<BookingModel> bookingsInFile = await _bookingService.LoadDataAsync();

            Assert.AreEqual(Bookings.Count, bookingsInFile.Count);

            foreach (var b in bookingsInFile) {
                var expected = Bookings.First(o => o.Id == b.Id);
                var actual = bookingsInFile.First(o => o.Id == b.Id);

                Assert.AreEqual(expected.Id, actual.Id);
                Assert.AreEqual(expected.CheckOut, actual.CheckOut);
                Assert.AreEqual(expected.CheckIn, actual.CheckIn);
                Assert.AreEqual(expected.TotalPrice, actual.TotalPrice);

                /*
                Assert.AreEqual(expected.Accommodation.Name, actual.Accommodation.Name);
                Assert.AreEqual(expected.Accommodation.Address, actual.Accommodation.Address);
                Assert.AreEqual(expected.Accommodation.Id, actual.Accommodation.Id);
                Assert.AreEqual(expected.Accommodation.NumberOfRooms, actual.Accommodation.NumberOfRooms);
                Assert.AreEqual(expected.Accommodation.Price, actual.Accommodation.Price);
                Assert.AreEqual(expected.Accommodation.Rating, actual.Accommodation.Rating);
                */
            }
            


        }
    }
}
