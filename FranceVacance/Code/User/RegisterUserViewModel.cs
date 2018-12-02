using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Media.Capture.Frames;
using Windows.UI.Popups;
using FranceVacance.Code.Common;
using FranceVacance.Code.Helpers;

namespace FranceVacance.Code.User
{
    class RegisterUserViewModel: ViewModelBase

    {
   
        private string _vUsername;
        private string _vPass;
        private string _vConfirmPass;
        private string _vEmail;
        public string UserError;
        public string PassError;
        public string ConfirmPassError;
        public string EmailError;


        public RelayCommand CreatingAnAccount { get; set; }
        public string VUsername
        {
            get { return _vUsername; }
            set
            {
                _vUsername = value;
                OnPropertyChanged("VUsername");
            }
        }

        public string VPass
        {
            get { return _vPass; }
            set
            {
                _vPass = value;
                OnPropertyChanged("VPass");
            }
        }
        public string VConfirmPass
        {
            get { return _vConfirmPass; }
            set
            {
                _vConfirmPass = value;
                OnPropertyChanged("VConfirmPass");
            }
        }

        public string VEmail
        {
            get { return _vEmail; }
            set
            {
                _vEmail = value;
                OnPropertyChanged("VEmail");
            }
        }
        


        // not using it now
        public string ErrorMessage
        {
            get { return _vEmail; }

        set {
            _vEmail = value;
            OnPropertyChanged("ErrorMessage");
        }
        }


        

        public bool Validation()
        {
           // VUsername;
           // VPass;
           // VEmail;
            return true;
        }
       

        //public async void CreateUser()
        //{

        //   // UserInfo NewUser = new UserInfo(VUsername,VPass,VEmail);
        //    RegisteredUsers.Add(NewUser);
        //    await _userService.SaveDataAsync(RegisteredUsers);

        //}
        public RegisterUserViewModel()
        {
            UserViewModel.Instance.LoadData();
            CreatingAnAccount = new RelayCommand(AddUser);
            VUsername = "";
            VConfirmPass = "";
            VEmail = "";
            VPass = "";
            
        }
        //Just Borislav's creation:
        //Just a test to see, if we can create it that way,
        //This one is for successfully created account 
        async Task ShowDialog()
        {
            MessageDialog dialog = new MessageDialog("Account created successfully","You created an account.");
            await dialog.ShowAsync();

        }
       
        //UPDATE:  So we can but it has to be different one for each 😁😜
        //I just havent looked at Boolean converter yet :) ;
        async Task EmailErrorMessage()
        {
            MessageDialog dialog = new MessageDialog("Invalid e-mail", "Please, enter valid e-mail adress");
            await dialog.ShowAsync();

        }

        private async void AddUser()
        {
            var UserVmInstance = UserViewModel.Instance;
            bool isValid = Validation();
            if (isValid)
            {
                UserModel newUser = new UserModel(VUsername, VPass, VEmail);

                UserVmInstance.RegisteredUsers.Add(newUser);
                UserVmInstance.SaveData();
                ShowDialog();



            }
            
            else
            {
                EmailErrorMessage();

            }

        }



    }
}
