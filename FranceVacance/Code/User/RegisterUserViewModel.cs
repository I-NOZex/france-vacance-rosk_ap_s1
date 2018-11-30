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
        private string _VUsername;
        private string _VPass;
        private string _VConfirmPass;
        private string _VEmail;
        private UserService _userService;
        public UserInfo _userInfo;
        public string VUsername
        {
            get { return _VUsername; }
            set { _VUsername = value; }
        }

        public string VPass
        {
            get { return _VPass; }
            set { _VPass = value; }
        }
        public string VConfirmPass
        {
            get { return _VConfirmPass; }
            set { _VConfirmPass = value; }
        }

        public string VEmail
        {
            get { return _VEmail; }
            set
            {
                _VEmail = value;
               // OnPropertyChanged("LIST");
            }
        }

        public string ErrorMessage
        {
            get { return _VEmail; }

        set {
            _VEmail = value;
            OnPropertyChanged("ErrorMessage");
        }
        }


        ObservableCollection<UserInfo> RegisteredUsers = new ObservableCollection<UserInfo>();

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
            bool IsValid = Validation();
            if (IsValid)
            {
                UserInfo NewUser = new UserInfo(VUsername, VPass, VEmail);

                RegisteredUsers.Add(NewUser);
                await _userService.SaveDataAsync(RegisteredUsers);

            }
            
            else
            {
                ErrorMessage = "Input ERROR🔫";
            }

        }



    }
}
