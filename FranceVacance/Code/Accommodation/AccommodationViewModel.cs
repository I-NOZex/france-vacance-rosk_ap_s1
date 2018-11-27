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
            }
        }

        public async Task LoadData() {
            Accommodations = await _accommodationService.LoadDataAsync();
        }

        public AccommodationViewModel() {
            _accommodationService = new AccommodationService();
            Accommodations = new ObservableCollection<AccommodationModel>();
        }
    }
}
