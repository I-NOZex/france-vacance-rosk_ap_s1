using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FranceVacance.Code.User
{
    class UserViewModel

    {
        private string _VUsername;
        private string _VPass;
        private string _VConfirmPass;
        private string _VEmail; 

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
            set { _VEmail = value; }

        }
        ObservableCollection<UserInfo> RegisteredUsers = new ObservableCollection<UserInfo>();

        public void Validation()
        {
            VUsername;
            VPass;
            VEmail;

        }
    
        public void CreateUser()
        {

            UserInfo NewUser = new UserInfo(VUsername,VPass,VEmail);
           RegisteredUsers.Add(NewUser);
        }

        public UserViewModel()
        {
            
        }

        


    }
}
