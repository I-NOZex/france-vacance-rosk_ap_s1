using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FranceVacance.Code.User {
    public class LoginViewModel {
        private string _username { get; set; }
        private string _password { get; set; }
        private string _confirmPassword { get; set; }
        private string _email { get; set; }
        private UserViewModel _userViewModel;

        public string Username {
            get { return _username; }
            set { _username = value; }
        }

        public string Password {
            get { return _password; }
            set { _password = value; }
        }
        public string ConfirmPassword {
            get { return _confirmPassword; }
            set { _confirmPassword = value; }
        }

        public string Email {
            get { return _email; }
            set { _email = value; }
        }

        public LoginViewModel() {
            _userViewModel.LoadData();
        }

        public UserModel GetUser() {
            //search inside the _userViewModel.RegisteredUsers for the user which have
            //the same email and password as inputed in the form
            //if there's a match:
                //return the match
            //else
                return null;
        }

        public void Login() {
            //get login form data
            // invoke GetUser()
                // if finds the user:
                    //set _userViewModel.CurrentUser as the matched user
                // else:
                    // show an error
        }
    }
}
