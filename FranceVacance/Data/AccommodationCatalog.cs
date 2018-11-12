using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FranceVacance.Model;

namespace FranceVacance.Data {
    public class AccommodationCatalog {
        private ObservableCollection<AccommodationModel> _accommodations { get; set;  }

        public ObservableCollection<AccommodationModel> Accommodations {
            get { return _accommodations; }
            set {
                _accommodations = value;
            }
        }

        public AccommodationCatalog() {
            Accommodations = new ObservableCollection<AccommodationModel>();
            foreach (var idx in Enumerable.Range(0, 10)) {
                Accommodations.Add(
                    new AccommodationModel() {
                        Id = idx,
                        Address = "Address placeholder",
                        Availability = true,
                        Name = $"Demo accommodation #{idx}",
                        NumberOfRooms = new Random().Next(1, 8),
                        Price = Math.Pow(3,idx),
                        Rating = new Random().Next(0, 5),
                    }
                );
            }
        }
    }
}
