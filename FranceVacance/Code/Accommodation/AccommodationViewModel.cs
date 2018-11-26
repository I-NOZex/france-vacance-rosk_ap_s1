using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using FranceVacance.Code.Common;

namespace FranceVacance.Code.Accommodation {
    public class AccommodationViewModel : ViewModelBase {
        private ObservableCollection<AccommodationModel> _accommodations { get; set;  }
        private AccommodationService _accommodationService;

        public ObservableCollection<AccommodationModel> Accommodations {
            get { return _accommodations; }
            set {
                _accommodations = value;
                OnPropertyChanged("Accommodations");
                OnPropertyChanged("AccommodationsFiltered");
                Debug.WriteLine("Accommodations changed");
            }
        }

        public async Task LoadData() {
            _accommodationService = new AccommodationService();
            Accommodations = new ObservableCollection<AccommodationModel>();
            Accommodations = await _accommodationService.LoadDataAsync();
        }

        public AccommodationViewModel() {
            //LoadData();
            //_accommodationService.LoadData();


            /*Accommodations = new ObservableCollection<AccommodationModel>();
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
            }*/

        }
    }
}
