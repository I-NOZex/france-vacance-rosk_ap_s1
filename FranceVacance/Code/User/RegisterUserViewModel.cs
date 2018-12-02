using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using FranceVacance.Code.Common;
using FranceVacance.Code.Helpers;

namespace FranceVacance.Code.User
{
    public class RegisterUserViewModel : ViewModelBase

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
        public RegisterUserViewModel()
        {
            UserViewModel.Instance.LoadData();
            CreatingAnAccount = new RelayCommand(AddUser);
            VUsername = "";
            VConfirmPass = "";
            VEmail = "";
            VPass = "";

        }

        public bool StringValidator(string input)
        {
            string pattern = "[a-zA-Z]";
            if (Regex.IsMatch(input, pattern))
            {
                return true;

            }

            return false;

        }

        public bool EmailValidator(string input)
        {
            string pattern = "[\\w-]+@([\\w-]+\\.)+[\\w-]+";
            if (Regex.IsMatch(input, pattern))
            {
                return true;
            }

            return false;
        }
        public bool IntegerValidator(string input)
        {
            string pattern = "[^0-9]";
            if (Regex.IsMatch(input, pattern))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void ClearText(string user, string pass)
        {
            user = String.Empty;
            pass = String.Empty;
        }


        public bool ValidationData()
        {
           
            //check if the email is valid
            if (StringValidator(VUsername) == false)
            {
                ErrorMessage = "Enter valid username";
                return false;
            }
            // checks if the pass has more than 8 characters
            else if (VPass.Length < 8)
            {
               
                PassError = "The password is below 8 characters!";

            }
            //check if the email is valid
            else if (EmailValidator(VEmail) == false)
            {
                EmailError = "Enter valid email";
                return false;
            }
          else if (VPass != ConfirmPassError)
            {
                ConfirmPassError = "Password doesn't match";
                return false;
            }

            foreach (var user in UserViewModel.Instance.RegisteredUsers)
            {
                if (VEmail == user.Email)
                {
                EmailError = "Email is not available";
                    return false;
                }
            }

            return true;
        }

    public string ErrorMessage
    {
        get { return _vEmail; }

        set
        {
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
    public RelayCommand CreatingAnAccount { get; set; }

        //public async void CreateUser()
        //{

        //   // UserInfo NewUser = new UserInfo(VUsername,VPass,VEmail);
        //    RegisteredUsers.Add(NewUser);
        //    await _userService.SaveDataAsync(RegisteredUsers);

        //}
        private async void AddUser()
        {
            var UserVmInstance = UserViewModel.Instance;
            bool isValid = Validation();
            if (isValid)
            {
                UserModel newUser = new UserModel(VUsername, VPass, VEmail);

                UserVmInstance.RegisteredUsers.Add(newUser);
                UserVmInstance.SaveData();
            }

        }




    }
}
