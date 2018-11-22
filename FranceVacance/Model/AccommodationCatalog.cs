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

            foreach (var idx in Enumerable.Range(0, 10)) {
                Accommodations.Add(
                    new AccommodationModel() {
                        Id = idx,
                        Address = addresses.ElementAt(r.Next(addresses.Count-1)),
                        Name = $"Demo accommodation #{idx}",
                        NumberOfRooms = r.Next(1, 8),
                        Price = Math.Pow(3,idx),
                        Rating = r.Next(0, 5),
                    }
                );
            }
        }
    }
}
