using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FranceVacance.Model;

namespace FranceVacance.Data {
    public class AccommodationCatalog {
        public List<AccommodationModel> Accommodations;
        public AccommodationCatalog() {
            Accommodations = new List<AccommodationModel>();
            foreach (var idx in Enumerable.Range(0, 10)) {
                Accommodations.Add(
                    new AccommodationModel() {
                        Id = idx,2
                        Address = "Address placeholder",
                        Availability = true,
                        Name = $"Demo accommodation #{idx}",
                        NumberOfRooms = new Random().Next(1, 8),
                        Price = new Random().Next(70, 700000),
                        Rating = new Random().Next(0, 5)
                    }
                );
            }
        }
    }
}
