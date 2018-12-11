using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FranceVacance.Code.Common;
using FranceVacance.Code.Helpers;
using FranceVacance.Code.User;

namespace FranceVacance.Code.Accommodation
{
    class VmCreatingAccommodation : ViewModelBase
    {
        private string _vname;
        private double _vprice;
        private string _vaddress;
        private AccommodationService _accommodationService;
        private AccommodationModel _accommodationModel;
        private RelayCommand Creatingaccommodation { get; set; }

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
            Vprice = Convert.ToDouble("");
            Vaddress = "";
            Vname = "";


        }

        private void AddAccommodation()
        {
            var accomodation=AccommodationViewModel.FirstInstance;
            if (ValidateData())
            {
                AccommodationModel newAccommodation=new AccommodationModel();
                newAccommodation.Price = Vprice;
                newAccommodation.Address = Vaddress;
                newAccommodation.Name = Vname;
        

            }
        }
    }
}
