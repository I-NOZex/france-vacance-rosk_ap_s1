using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FranceVacance.Code.User
{
    //Singleton Class
    public class UserViewModel
    {

        private static UserViewModel instance = new UserViewModel();


        static UserViewModel()
        {
        }

        private UserViewModel()
        {
            _userService = new UserService();
            RegisteredUsers = new ObservableCollection<UserModel>();
            CurrentUser = new UserModel();
            LoggingInUser = new LoginViewModel();

        }

        private UserService _userService;
        public ObservableCollection<UserModel> RegisteredUsers;
        public UserModel CurrentUser;
        public LoginViewModel LoggingInUser;

        public static UserViewModel Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new UserViewModel();
                }
                return instance;
            }
        }

        public async Task LoadData(bool force = false)
        {
            if (RegisteredUsers.Count == 0 || force)
                RegisteredUsers = await _userService.LoadDataAsync();
        }


        public async Task SaveData()
        {
            await _userService.SaveDataAsync(RegisteredUsers);
        }

        public UserModel GetUser(string email, string password)
        {
            //search inside the _userViewModel.RegisteredUsers for the user which have
            foreach (var user in RegisteredUsers)
            {
                // think this is the way it is supposed to go with the search 😁
                
                if (CurrentUser.Email == email) // I'm not sure if this goes with email or username it doest matter but i will forget to ask  tomorrow/today😁
                {
                    if (CurrentUser.Password == password)
                    {
                        return user;
                    }
                    else
                    {
                        // I know this is not the proper way but still I don't know
                        //what it is supposed to return 😁 maybe some message like in  the registration form
                        return null;
                    }
                    
                }
                else
                {
                    //same here, maybe some message like you can go and create an account
                    //
                    //😁 
                    return null;
                }
            }
            //the same email and password as inputed in the form
            //if there's a match:
            //return the match
            //else
            return null;
        }

    }
}