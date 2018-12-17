using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;
using FranceVacance.Code.Common;
using FranceVacance.Code.Helpers;
using FranceVacance.Code.Search;

namespace FranceVacance.Code.User {
    public class LoginViewModel : ViewModelBase {
        private string _password { get; set; }
        private string _username { get; set; }
        private string _credentialsError { get; set; }

        public RelayCommand LoginCommand { get; set; }

        public string Password {
            get { return _password; }
            set { _password = value; }
        }

        public string Username {
            get { return _username; }
            set { _username = value; }
        }

        public string CredentialsError {
            get => _credentialsError;
            set {
                _credentialsError = value;
                OnPropertyChanged("CredentialsError");
            }
        }


        public LoginViewModel() {
            UserViewModel.Instance.LoadData();
            LoginCommand = new RelayCommand(o => Login());
        }



        public bool Login() {
            //get login form data
            UserModel user = UserViewModel.Instance.GetUser(Username, Password);

            if (user == null) {
                CredentialsError = "Your username or password is incorrect.";
            } else if(!Enum.IsDefined(typeof(UserRole), user.Role) || user.Role.Equals(UserRole.Inactive)) {
                CredentialsError = "You don't have permissions to access this.";
            } else {
                UserViewModel.Instance.CurrentUser = user;
                return true;
            }

            return false;
        }
    }
}
