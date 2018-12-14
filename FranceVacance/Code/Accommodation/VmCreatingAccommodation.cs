using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FranceVacance.Code.Common;
using FranceVacance.Code.Helpers;
using FranceVacance.Code.User;

namespace FranceVacance.Code.Accommodation
{
    public class VmCreatingAccommodation : ViewModelBase
    {
        private string _vname;
        private double _vprice;
        private string _vaddress;
        private AccommodationService _accommodationService;
        private AccommodationModel _accommodationModel;
        public RelayCommand Creatingaccommodation { get; set; }
        public ObservableCollection<AccommodationModel> AccommodationModelList;
        public string Vname
        {
            get { return _vname; }
            set
            {
                _vname = value;
                OnPropertyChanged("Vname");
            }
        }

        public double Vprice
        {
            get { return _vprice; }
            set
            {
                _vprice = value;
                OnPropertyChanged("Vprice");
            }
        }

        public string Vaddress
        {
            get { return _vaddress; }
            set
            {
                _vaddress = value;
                OnPropertyChanged("Vaddress");
            }
        }

        public VmCreatingAccommodation()
        {
           Creatingaccommodation =new RelayCommand(AddAccommodation);
           _accommodationService = new AccommodationService();
            LoadData();

        }
        public async Task LoadData(bool force = false)
        {
            if (AccommodationModelList == null || AccommodationModelList.Count == 0 || force)
                AccommodationModelList = await _accommodationService.LoadDataAsync();

        }
        public async Task SaveData()
        {
            await _accommodationService.SaveDataAsync(AccommodationModelList);
        }

        private void AddAccommodation()
        {
            
            if (true)
            {
                AccommodationModel newAccommodation=new AccommodationModel();
                newAccommodation.Price = Vprice; 
                newAccommodation.Address = Vaddress;
                newAccommodation.Name = Vname;
                AccommodationModelList.Add(newAccommodation);
                SaveData();



            }
        }
    }
}
