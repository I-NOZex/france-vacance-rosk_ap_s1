using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        private UserService _userService;
        private UserModel _userModel;
        public string UserError;
        public string PassError;
        public string ConfirmPassError;
        public string EmailError;
        public string VUsername
        {
            get { return _vUsername; }
            set { _vUsername = value; }
        }

        public string VPass
        {
            get { return _vPass; }
            set { _vPass = value; }
        }
        public string VConfirmPass
        {
            get { return _vConfirmPass; }
            set { _vConfirmPass = value; }
        }

        public string VEmail
        {
            get { return _vEmail; }
            set
            {
                _vEmail = value;
               // OnPropertyChanged("LIST");
            }
        }
        



        public string ErrorMessage
        {
            get { return _vEmail; }

        set {
            _vEmail = value;
            OnPropertyChanged("ErrorMessage");
        }
        }


        ObservableCollection<UserModel> _registeredUsers = new ObservableCollection<UserModel>();

        public bool Validation()
        {
           // VUsername;
           // VPass;
           // VEmail;
            return true;
        }
        public RelayCommand CreatingAnAccount { get; set; }

        //public async void CreateUser()
        //{

        //   // UserInfo NewUser = new UserInfo(VUsername,VPass,VEmail);
        //    RegisteredUsers.Add(NewUser);
        //    await _userService.SaveDataAsync(RegisteredUsers);

        //}
        public RegisterUserViewModel()
        {
            _userService = new UserService();
            CreatingAnAccount = new RelayCommand(AddUser);
            VUsername = "";
            VConfirmPass = "";
            VEmail = "";
            VPass = "";

        }
        private async void AddUser()
        {
            bool isValid = Validation();
            if (isValid)
            {
                UserModel newUser = new UserModel(VUsername, VPass, VEmail);

                _registeredUsers.Add(newUser);
                await _userService.SaveDataAsync(_registeredUsers);

            }
            
            else
            {
                ErrorMessage = "Input ERROR🔫";
            }

        }



    }
}
