using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FranceVacance.Code.User {
    public class LoginViewModel {
        private string _password { get; set; }
        private string _email { get; set; }
        private UserViewModel _userViewModel;

        public string Password {
            get { return _password; }
            set { _password = value; }
        }

        public string Email {
            get { return _email; }
            set { _email = value; }
        }

        public LoginViewModel() {
            _userViewModel.LoadData();
        }



        public void Login() {
            //get login form data
            // invoke _userViewModel.Instance.GetUser()
                // if finds the user:
                    //set _userViewModel.Instance.CurrentUser as the matched user
                // else:
                    // show an error
        }
    }
}
