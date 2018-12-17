

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FranceVacance.Code.User {
    public class UserModel {
        private int _id { get; set; }
        private string _username { get; set; }
        private string _email { get; set; }
        private string _password { get; set; }
        private UserRole _role { get; set; }

        public string Username {
            get { return _username; }
            set { _username = value; }
        }

        public string Password {
            get { return _password; }
            set { _password = value; }
        }

        public string Email {
            get { return _email; }
            set { _email = value; }
        }

        public UserRole Role {
            get { return _role; }
            set { _role = value; }
        }

        public bool IsAdmin {
            get { return Role.Equals(UserRole.Admin); }
        }

        public UserModel(string username, string password, string email) {
            Username = username;
            Password = password;
            Email = email;
        }

        public UserModel() {
        }
    }
}

