using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FranceVacance.Code.User {
    //Singleton Class
    public class UserViewModel{

        private static readonly UserViewModel instance = new UserViewModel();


        static UserViewModel() {
        }

        private UserViewModel() {
            _userService = new UserService();
            RegisteredUsers = new ObservableCollection<UserModel>();
            CurrentUser = new UserModel();
        }

        private UserService _userService;
        public ObservableCollection<UserModel> RegisteredUsers;
        public UserModel CurrentUser;

        public static UserViewModel Instance {
            get {
                return instance;
            }
        }

        public async Task LoadData(bool force = false) {
            if(RegisteredUsers.Count == 0 || force)
                RegisteredUsers = await _userService.LoadDataAsync();
        }


        public async Task SaveData()
        {
            await _userService.SaveDataAsync(RegisteredUsers);
        }

        public UserModel GetUser() {
            //search inside the _userViewModel.RegisteredUsers for the user which have
            //the same email and password as inputed in the form
                //if there's a match:
                    //return the match
                //else
                    return null;
        }

    }
}
