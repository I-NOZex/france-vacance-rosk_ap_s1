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
        private string _userError { get; set; }
        private string _passError { get; set; }
        private string _confirmPassError { get; set; }
        private string _emailError { get; set; }

        private UserService _userService;
        private UserModel _userModel;
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

        public string UserError
        {
            get => _userError;
            set
            {
                _userError = value;
                OnPropertyChanged("UserError");
            }
        }

        public string PassError
        {
            get => _passError;
            set
            {
                _passError = value;
                OnPropertyChanged("PassError");
            }
        }

        public string ConfirmPassError
        {
            get => _confirmPassError;
            set
            {
                _confirmPassError = value;
                OnPropertyChanged("ConfirmPassError");
            }
        }

        public string EmailError
        {
            get => _emailError;
            set
            {
                _emailError = value;
                OnPropertyChanged("EmailError");
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


        public bool ValidateData()
        {
            ConfirmPassError = "";
            UserError = "";
            EmailError = "";
            PassError = "";

            //check if the email is valid
            if (StringValidator(VUsername) == false)
            {
                UserError = "Enter valid username";
                return false;
            }

            // checks if the pass has more than 8 characters
            else if (VPass.Length < 8)
            {          
                PassError = "The password is below 8 characters!";
                return false;
            }

            //check if the email is valid
            else if (EmailValidator(VEmail) == false)
            {
                EmailError = "Enter valid email";
                return false;
            }

            else if (VPass != VConfirmPass)
            {
                ConfirmPassError = "Password doesn't match";
                return false;
            }

            foreach (var user in UserViewModel.Instance.RegisteredUsers)
            {
                if (VEmail == user.Email)
                { 
                EmailError = "Username is not available";
                    return false;
                }
            }

            return true;
        }

        private void AddUser()
        {
            var UserVmInstance = UserViewModel.Instance;

            if (ValidateData())
            {
                UserModel newUser = new UserModel(VUsername, VPass, VEmail);

                UserVmInstance.RegisteredUsers.Add(newUser);
                UserVmInstance.SaveData();
            }

        }

    }
}
