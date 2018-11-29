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
        private static AccommodationViewModel _firstInstance = null;

        public ObservableCollection<AccommodationModel> Accommodations {
            get { return _accommodations; }
            set {
                _accommodations = value;
                OnPropertyChanged("Accommodations");
            }
        }

        // FIXME: we have this static reference for the 1st created instance because it's needed
        // in order to map the accommodation id of the booking to the actual instance of the accommodation

        public static AccommodationViewModel FirstInstance {
            get {
                if (_firstInstance == null) {
                    _firstInstance = new AccommodationViewModel();
                }
                return _firstInstance;
            }
        }

        public async Task LoadData() {
            Accommodations = await _accommodationService.LoadDataAsync();
        }

        public AccommodationViewModel()
        {
            _accommodationService = new AccommodationService();
            Accommodations = new ObservableCollection<AccommodationModel>();
        }

    }
}
