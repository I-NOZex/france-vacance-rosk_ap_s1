﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Security.Principal;
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

        public bool SetAsAdmin { get; set; }

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
            CreatingAnAccount = new RelayCommand(o => AddUser());
            VUsername = "";
            VConfirmPass = "";
            VEmail = "";
            VPass = "";
            SetAsAdmin = false;
        }

        public bool StringValidator(string input)
        {
            string pattern = "^([a-zA-Z0-9]+)$";
            if (Regex.IsMatch(input, pattern))
            {
                return true;

            }

            return false;

        }

        public bool EmailValidator(string input)
        {
            string pattern = "^([\\w-]+@([\\w-]+\\.)+[\\w-]+)$";
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

            //check if the username is valid
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
                EmailError = "Email is not available";
                    return false;
                }

                if (VUsername == user.Username) {
                    UserError = "Username is not available";
                    return false;
                }
            }

            return true;
        }

        public bool AddUser()
        {

            var UserVmInstance = UserViewModel.Instance;
            bool isValid = ValidateData();
            if (isValid)
            {
                UserModel newUser = new UserModel(VUsername, VPass, VEmail);
                newUser.Role = SetAsAdmin ? UserRole.Admin : UserRole.Customer;
                UserVmInstance.RegisteredUsers.Add(newUser);
                UserVmInstance.SaveData();
            }

            return isValid;
        }

    }
}
