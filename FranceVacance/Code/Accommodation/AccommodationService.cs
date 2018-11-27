using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using  FranceVacance.Code.Helpers;

namespace FranceVacance.Code.Accommodation {
    public class AccommodationService : FileService<AccommodationModel> {
        private const string FILE_NAME = "accommodations.json";

        public async Task<ObservableCollection<AccommodationModel>> LoadDataAsync() {
            return await LoadData(FILE_NAME);
        }

        public async Task<bool> SaveDataAsync(ObservableCollection<AccommodationModel> accommodationCollection) {
            return await SaveData(FILE_NAME, accommodationCollection);
        }

        /*public AccommodationService(AccommodationViewModel accommodationViewModel) {
            _accommodationViewModel = accommodationViewModel;
        }*/
    }
}
