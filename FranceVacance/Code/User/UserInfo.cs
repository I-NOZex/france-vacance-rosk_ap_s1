using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FranceVacance.Code.User
{
    class UserInfo
    {
        private int _id { get; set; }
        private string _username { get; set; }
        private string _email { get; set; }
        private string _pass { get; set; }

        public string Username
        {
            get { return _username; }
            set { _username = value; }
        }

        public string Pass
        {
            get { return _pass; }
            set { _pass = value; }
        }

        public string Email
        {
            get { return _email; }
            set { _email = value; }
        }

        public UserInfo(string username, string pass, string email)
        {
            username = Username;
            pass = Pass;
            email = Email;


        }
    }
}
