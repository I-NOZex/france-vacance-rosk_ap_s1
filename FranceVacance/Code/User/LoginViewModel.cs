﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FranceVacance.Code.Common;

namespace FranceVacance.Code.User {
    public class LoginViewModel : ViewModelBase {
        private string _password { get; set; }
        private string _email { get; set; }

        public string Password {
            get { return _password; }
            set { _password = value; }
        }

        public string Email {
            get { return _email; }
            set { _email = value; }
        }

        public LoginViewModel() {
            UserViewModel.Instance.LoadData();
            
        }



        public void Login() {
            //get login form data
            UserModel user = UserViewModel.Instance.GetUser(Email, Password);
            if (user != null)
                UserViewModel.Instance.CurrentUser = user;
            // if finds the user:
            //set _userViewModel.Instance.CurrentUser as the matched user
            // else:
            // show an error
        }
    }
}
